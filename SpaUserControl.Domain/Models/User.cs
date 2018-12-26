using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaUserControl.Common.Resources;
using SpaUserControl.Common.Validation;

namespace SpaUserControl.Domain.Models
{

    public class User
    {

        protected User() {}

        public User(string Name, string Email)
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.Email = Email;
            
        }


        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string password { get; private set; }


        public void SetPassword(string password, string confirmPassword)
        {

            AssertionConcern.AssertArgumentNotNull(password,Errors.InvalidPassword);
            AssertionConcern.AssertArgumentNotNull(confirmPassword, Errors.InvalidPasswordConfirm);
            AssertionConcern.AssertArgumentNotEquals(password, confirmPassword, Errors.PasswordNotMatch);
            AssertionConcern.AssertArgumentLength(password, 6, 10, Errors.InvalidPassword);

            this.password = password;

        }

        public string ResetPassword()
        {
            string password = Guid.NewGuid().ToString().Substring(0, 8);

            return password;
        }

        public string ChangeName(string name){
            this.Name = name;
            return name;
}    
        
        public void Validate(){
            AssertionConcern.AssertArgumentLength(this.Name, 3, 250, "nome invalido");
}
    }
}
