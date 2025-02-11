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
        
        [TestCase(false, TestName = "give false when validator doesn't allow the password")]
        [TestCase(true, TestName = "give true when validator allows the password")]
        public void give_result_of_validation(bool isValid){
            string password = "hello";

            var result = new PasswordValidatorContext( new MockPasswordValidator(isValid)).ValidatePassword(password);

            result.Should().Be(isValid);
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