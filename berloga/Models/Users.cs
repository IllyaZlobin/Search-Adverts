using Microsoft.AspNetCore.Identity;

namespace berloga.Models
{
    public class Users : IdentityUser
    {
        public string login { get; set; }

        public string parol { get; set; }

        public string name { get; set; }

        public string surname { get; set; }

        public string about_yourstlf { get; set; }

        //Хочу что-то сделать в этом класе!
    }
}