using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ADETProjApp
{
    public class UserDataEntryValidation
    {
        public string userName {  get; private set; }
        public string name { get; private set; }
        public string address { get; private set; }
        public string contactNo { get; private set; }
        public string email {  get; private set; }
        public string password { get; private set; }
        public string cPassword { get; private set; }
        private string error = "";

        public UserDataEntryValidation(string userName, string name, string address, string contactNo, string email, string password, string cPassword)
        {
            this.userName = userName;
            this.name = name;
            this.address = address;
            this.contactNo = contactNo;
            this.email = email;
            this.password = password;
            this.cPassword = cPassword;
        }

        public string Validate()
        {
            Regex nameRegex = new Regex(@"^[a-zA-Z\s]*$");
            Regex numRegex = new Regex(@"^\d+$");
            Regex emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (this.userName == "")
            {
                error = "Enter a username.";
                return error;
            }

            if (this.userName.Contains(" "))
            {
                error = "Please don't include space/s in username.";
                return error;
            }

            if (this.userName.Length > 32)
            {
                error = "Username should only contain 32 characters.";
                return error;
            }

            if (this.name == "")
            {
                error = "Enter a name.";
                return error;
            }

            if (this.name.Length > 80)
            {
                error = "Name should only contain 80 characters.";
                return error;
            }

            if (!nameRegex.IsMatch(this.name))
            {
                error = "Name should only have letters and spaces.";
                return error;
            }

            if (this.address == "")
            {
                error = "Enter an address.";
                return error;
            }

            if (this.address.Length > 265)
            {
                error = "Address should only contain 256 characters";
                return error;
            }

            if (this.contactNo == "")
            {
                error = "Enter a contact number.";
                return error;
            }

            if (!numRegex.IsMatch(this.contactNo) || this.contactNo.Length != 11)
            {
                error = "Please input a valid contact number.";
                return error;
            }

            if (this.email == "")
            {
                error = "Enter an email.";
                return error;
            }
            
            if (this.email.Length > 256 || !emailRegex.IsMatch(this.email))
            {
                error = "Enter a valid email";
                return error;
            }
            
            if (this.password == "")
            {
                error = "Enter a password.";
                return error;
            }
            
            if(this.password.Contains(" "))
            {
                error = "Password shouldn't contain space/s.";
                return error;
            }

            if(this.password != this.cPassword)
            {
                error = "Password doesn't match.";
            }

            return error;
        }

    }
}
