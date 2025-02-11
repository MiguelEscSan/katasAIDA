using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using FluentAssertions;


namespace PasswordValidator.Tests
{
    public class PasswordValidatorContextShould
    {

        [Test]
        public void give_false() {
            string password = "";

            var result = new PasswordValidatorContext(new MockPasswordValidator(false)).ValidatePassword(password);

            result.Should().BeFalse();
            
        }

        [Test]  
        public void give_true() {
            string password = "hello";

            var result = new PasswordValidatorContext( new MockPasswordValidator(true)).ValidatePassword(password);

            result.Should().BeTrue();
        }

        class MockPasswordValidator : IPasswordValidator {

            bool isValid;
    
            public MockPasswordValidator(bool isValid) {
                this.isValid = isValid;
            }
            public bool ValidatePassword(string password){

                return this.isValid;
            }
        }
        
    }

    public class PasswordValidatorContext {

        IPasswordValidator passwordValidator;

        public PasswordValidatorContext( IPasswordValidator passwordValidator) {
            this.passwordValidator = passwordValidator;

        }

        public bool ValidatePassword(string password) {
            return passwordValidator.ValidatePassword("");
        }
    }
}