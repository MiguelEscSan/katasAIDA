using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;


namespace PasswordValidator.Tests
{
    public class PasswordValidatorContextShould
    {

        [Test]
        public void give_false() {
            string password = "";

            var result = new PasswordValidatorContext().ValidatePassword(password);

            result.Should().BeFalse();
            
        }
        
    }

    public class PasswordValidatorContext {

        public PasswordValidatorContext() {

        }

        public bool ValidatePassword(string password) {
            return false;
        }
    }
}