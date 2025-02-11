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
        public void not_allowed_when_password_has_less_than_sixteen_characters(){
            var password = "holaquetal";

            var result = new ThirdPasswordValidator().ValidatePassword(password);
            
            result.Should().BeFalse();

        }

        [Test]
        public void not_allowed_when_password_doesnt_have_upper_case(){
            var password = "holaquetalestosonm1asdecharacteres";

            var result = new ThirdPasswordValidator().ValidatePassword(password);
            
            result.Should().BeFalse();
        }

        [Test]
        public void not_allowed_when_password_doesnt_have_lowercase_characteres() {
            var password = "AAAAAAAAAAAAAAAAAAAAAAAA32_AAAAAAAAAAAAA";

            var result = new ThirdPasswordValidator().ValidatePassword(password);

            result.Should().BeFalse();
        }

        [Test]
        public void not_allowed_when_password_doesnt_have_underscore_charactere() {
            var password = "AAAAAAAAAAAAAAAAAAAAAaAA32AAAAAAAAAAAAA";

            var result = new ThirdPasswordValidator().ValidatePassword(password);

            result.Should().BeFalse();
        }

    }
}