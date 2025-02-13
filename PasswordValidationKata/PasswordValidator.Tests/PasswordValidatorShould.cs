using PasswordValidator.ValidationRules;

namespace PasswordValidator.Tests;
public class PasswordValidatorShould
{



        [Test]
        public void not_allowed_when_password_does_not_have_minimum_length(){
            var password = "";
            List<ValidationRule> rules = [ new HasAtLeastminimumCharacters(8)];

            var result = new  PasswordValidatorClass(rules).ValidatePassword(password);

            result.ShouldBe(false);
        
        }

        [Test]
        public void allow_when_passwordValidator_has_no_validation_rules(){
            var password = "";
            List<ValidationRule> rules = [];

            var result = new  PasswordValidatorClass(rules).ValidatePassword(password);

            result.ShouldBe(true);
        
        }

}