namespace user_service.Model
{
    public class UserDTO
    {
        
        public string id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int postal_code { get; set; }
        public string card_number { get; set; }
        public int loyalty_points { get; set; }
        public bool is_account_active { get; set; }
        public bool is_account_suspended { get; set; }
        public int verification_code { get; set; }

        public UserDTO(string id, string name, string surname, string password, string email, string address, int postal_code,
                    string card_number, int loyalty_points, bool is_account_active, bool is_account_suspended, int verification_code)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.password = password;
            this.email = email;
            this.address = address;
            this.postal_code = postal_code;
            this.card_number = card_number;
            this.loyalty_points = loyalty_points;
            this.is_account_active = is_account_active;
            this.is_account_suspended = is_account_suspended;
            this.verification_code = verification_code;
        }
    }
}
