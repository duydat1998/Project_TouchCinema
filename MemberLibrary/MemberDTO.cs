using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberLibrary
{
    public class MemberDTO
    {
        private string _username;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _phoneNum;
        private string _email;
        private DateTime _birthdate;
        private string _imageLink;
        private bool _isActive;

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string PhoneNum { get => _phoneNum; set => _phoneNum = value; }
        public string Email { get => _email; set => _email = value; }
        public DateTime Birthdate { get => _birthdate; set => _birthdate = value; }
        public string ImageLink { get => _imageLink; set => _imageLink = value; }
        public bool isActive { get => _isActive; set => _isActive = value; }

        public MemberDTO()
        {
        }
    }
}
