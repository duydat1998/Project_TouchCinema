using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberLibrary
{
    public class MemberDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string ImageLink { get; set; }
        public bool IsActive { get; set; }

        public MemberDTO()
        {
        }

        public MemberDTO(string username, string password, string firstName, string lastName, string phoneNum, string email, DateTime birthdate, string imageLink, bool isActive)
        {
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            PhoneNum = phoneNum;
            Email = email;
            Birthdate = birthdate;
            ImageLink = imageLink;
            IsActive = isActive;
        }
    }
}
