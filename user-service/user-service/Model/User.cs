namespace user_service.Model
{
    public class User : Person
    {
        public string card_number { get; set; }
        public int loyalty_points { get; set; }
        public bool is_account_active { get; set; }
        public bool is_account_suspended { get; set; }

        public User(UserDTO userDTO)
            : base(userDTO.id, userDTO.name, userDTO.surname, userDTO.password, userDTO.email, userDTO.address, userDTO.postal_code)
        {
            this.card_number = userDTO.card_number;
            this.loyalty_points = userDTO.loyalty_points;
            this.is_account_active = userDTO.is_account_active;
            this.is_account_suspended = userDTO.is_account_suspended;
        }

        public User(string id, string name, string surname, string password, string email, string address, int postal_code,
                    string card_number, int loyalty_points, bool is_account_active, bool is_account_suspended)
            : base(id, name, surname, password, email, address, postal_code)
        {
            this.card_number = card_number;
            this.loyalty_points = loyalty_points;
            this.is_account_active = is_account_active;
            this.is_account_suspended = is_account_suspended;
        }
    }
}