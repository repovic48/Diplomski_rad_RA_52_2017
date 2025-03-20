using user_service.Repositories;
using user_service.Model;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace user_service.Services 
{
    public class UserService : IUserService
    {
        private readonly IUserRepository user_repository;
        private readonly TokenProvider token_provider;

        public UserService(IUserRepository user_repository, TokenProvider token_provider)
        {
            this.user_repository = user_repository;
            this.token_provider = token_provider;
        }

        public string SayHello()
        {
            return user_repository.SayHello();
        }

        public async Task<User> RegisterUser(UserDTO new_userDTO)
        {
            User new_user = new User(new_userDTO);
            new_user.id = Guid.NewGuid().ToString();
            Random random = new Random();
            int verification_code = random.Next(1000, 10000);
            new_user.verification_code = verification_code;

            await SendEmail(new_user.email, new_user.verification_code);

            return await this.user_repository.RegisterUser(new_user);
        }

        public async Task<User?> UpdateUser(UserDTO userDTO)
        {
            User tempUser = new User(userDTO);

            if (tempUser != null)
            {
                var existingUser = await user_repository.GetUserByEmail(tempUser.email);
                if(existingUser != null){
                    var updated_user = await user_repository.UpdateUser(tempUser);
                    return updated_user;
                }
            }

            return null;
        }

        public async Task<User?> VerifyAccount(UserDTO userDTO)
        {
            User tempUser = new User(userDTO);
            
            if (tempUser != null)
            {   
                var existingUser = await user_repository.GetUserByEmail(tempUser.email);
                if(existingUser != null && existingUser.verification_code == tempUser.verification_code){
                    existingUser.is_account_active = true;
                    return await user_repository.UpdateUser(existingUser);
                }
                else{
                    return null;
                }
            }

            return null;
        }

        public async Task<string> Login(UserDTO userDTO)
        {
            User tempUser = new User(userDTO);

            var existingUser = await user_repository.GetUserByEmail(tempUser.email);

            if (existingUser != null && existingUser.password == tempUser.password)
            {
                string token = token_provider.Create(existingUser);
                return token;
            }

            return null;
        }

        public async Task<bool> DeleteUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            return await user_repository.DeleteUserByEmail(email);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await this.user_repository.GetAllUsers();
        }

        public async Task<string> GenerateVerificationMessage(string email)
        {
            var existingUser = await this.user_repository.GetUserByEmail(email);

            if (existingUser == null)
            {
                throw new ArgumentException("User not found.");
            }

            return $"Uspesno ste se registrovali, vas kod za verifikaciju je: {existingUser.verification_code}";
        }

        public async Task SendEmail(string recipientEmail, int verificationCode)
        {
            string sender_email = "narucirs.podrska@gmail.com";
            MailMessage mailMessage = new MailMessage(sender_email, recipientEmail);
            mailMessage.From = new MailAddress(sender_email);
            mailMessage.To.Add(recipientEmail);
            mailMessage.Subject = "Potvrda registracije";
            mailMessage.Body = $"Vas kod za potvrdu registracije: {verificationCode}";
            
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(sender_email, "whkn gznt iedy bcbt ");
            smtpClient.EnableSsl = true;

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine("Email Sent Successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        
    } 
}
