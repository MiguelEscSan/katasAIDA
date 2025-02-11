using FluentAssertions;

namespace PasswordValidator.Tests
{
    public class ThirdPasswordValidatorShould
    {
        [Test]
        public void not_allowed_when_password_is_empty(){
            var password ="";

            var result = new ThirdPasswordValidator().ValidatePassword(password);
            
            result.Should().BeFalse();

        }

        [Test]
        public void not_allow_when_password_has_less_than_sixteen_characters(){
            var password = "holaquetal";

            var result = new ThirdPasswordValidator().ValidatePassword(password);
            
            result.Should().BeFalse();

        }
    }
}