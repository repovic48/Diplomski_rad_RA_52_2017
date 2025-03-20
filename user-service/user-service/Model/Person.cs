using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace user_service.Model
{
    public class Person
    {
        [Key]
        public string id { get; set; }
        [Required]
        public  string name { get; set; }
        [Required]
        public  string surname { get; set; }
        [Required]
        public  string password { get; set; }

        [Required]
        public string email { get; set; }
        [Required]
        public  string address { get; set; }
        [Required]
        public int postal_code { get; set; }

        public Person(string id, string name, string surname, string password, string email, string address, int postal_code)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.password = password;
            this.email = email;
            this.address = address;
            this.postal_code = postal_code;
        }
        public Person() { }

    }
}
