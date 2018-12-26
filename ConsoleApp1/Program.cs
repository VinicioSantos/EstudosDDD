using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Models;
using SpaUserControl.InfraEstructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            User user = new User("Vinicio","Email");

            user.SetPassword("vinicio","vinicio");
            user.Validate();

            using (IUserRepository userRep = new UserRepository())
            {
                userRep.Create(user);
            }

            

            using (IUserRepository userRep = new UserRepository())
            {
                var usr = userRep.Get("Email");
                Console.WriteLine(usr.Email);
            }

            
            Console.ReadKey();

        }
    }
}
