using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLibrary
{
    public class AdminDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }


        public AdminDTO()
        {

        }

        public AdminDTO(string username, string password, string firstname, string lastname, string phone, string email)
        {
            this.Username = username;
            this.Password = password;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Phone = phone;
            this.Email = email;
        }
    }
}
