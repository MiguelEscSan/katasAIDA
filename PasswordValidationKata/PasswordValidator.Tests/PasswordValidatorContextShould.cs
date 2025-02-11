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

        [Test]
        public void use_the_password_for_validation() {

            var password = "hello";

            var spyPasswordValidator = new SpyPasswordValidator();
            var PasswordValidatorContext = new PasswordValidatorContext( spyPasswordValidator );
            PasswordValidatorContext.ValidatePassword(password);

            spyPasswordValidator.password.Should().Be(password);
        }

        class SpyPasswordValidator: IPasswordValidator {
            public string password;    

            public bool ValidatePassword(string password){
                this.password = password;
                return true;
            }
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
}