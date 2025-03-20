namespace user_service.Model
{
    using System;
    using System.ComponentModel;

    public enum UserType
    {
        [Description("Administrator")]
        Administrator,

        [Description("User")]
        User,
        [Description("Default")]
        Default
    }

    public class User : Person
    {
        public string card_number { get; set; }
        public int loyalty_points { get; set; }
        public bool is_account_active { get; set; }
        public bool is_account_suspended { get; set; }
        public int verification_code { get; set; }
        public UserType user_type { get; set; }
        public User() { }
        public User(UserDTO userDTO)
            : base(userDTO.id, userDTO.name, userDTO.surname, userDTO.password, userDTO.email, userDTO.address, userDTO.postal_code)
        {
            this.card_number = userDTO.card_number;
            this.loyalty_points = userDTO.loyalty_points;
            this.is_account_active = userDTO.is_account_active;
            this.is_account_suspended = userDTO.is_account_suspended;
            this.verification_code = userDTO.verification_code;
            this.user_type = Enum.TryParse(userDTO.user_type, true, out UserType parsed_user_type) ? parsed_user_type : throw new ArgumentException($"Invalid UserType value: {user_type}");
        }

        public User(string id, string name, string surname, string password, string email, string address, int postal_code,
                    string card_number, int loyalty_points, bool is_account_active, bool is_account_suspended, int verification_code,
                    string user_type)
            : base(id, name, surname, password, email, address, postal_code)
        {
            this.card_number = card_number;
            this.loyalty_points = loyalty_points;
            this.is_account_active = is_account_active;
            this.is_account_suspended = is_account_suspended;
            this.verification_code = verification_code;

            // Convert string to UserType enum safely
            if (Enum.TryParse(user_type, true, out UserType parsed_user_type))
            {
                this.user_type = parsed_user_type;
            }
            else
            {
                throw new ArgumentException($"Invalid UserType value: {user_type}");
            }
        }
    }
}