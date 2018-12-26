using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaUserControl.Common.Validation
{
    public class PasswordAssertionConcern
    {

        public static void AssertionIsValid(string password){

            AssertionConcern.AssertArgumentNotNull(password,"");
        }


    }
}
