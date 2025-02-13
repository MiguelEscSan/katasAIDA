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

        [Test]
        public void not_allowed_when_password_does_not_contain_uppercase(){
            var password = "holaestosonmasde22_ocho";
            List<ValidationRule> rules = [ new HasAtLeastminimumCharacters(8), new HasCapitalLetter()];

            var result = new  PasswordValidatorClass(rules).ValidatePassword(password);

            result.ShouldBe(false);
        }

        [Test]
        public void not_allowed_when_password_does_not_contain_lowercase(){
            var password = "HOLAMUNDOTENEMOS22LETRAS_JAAJA";
            List<ValidationRule> rules = [ new HasAtLeastminimumCharacters(8), new HasCapitalLetter(), new HasLowerCaseCharacter()];

            var result = new  PasswordValidatorClass(rules).ValidatePassword(password);

            result.ShouldBe(false);
        }

        [Test]
        public void not_allowed_when_password_does_not_contain_numeric_character(){
            var password = "HOLAMUNDOTecEMOSLETRAS_JAAJA";
            List<ValidationRule> rules = [ new HasAtLeastminimumCharacters(16), new HasCapitalLetter(), new HasLowerCaseCharacter(), new HasNumericCharacter()];

            var result = new  PasswordValidatorClass(rules).ValidatePassword(password);

            result.ShouldBe(false);
        }

        [Test]
        public void not_allowed_when_password_does_not_contain_underscor_character(){
            var password = "HOLAMUNDOTecEMOSLETRAS22JAAJA";
            List<ValidationRule> rules = [ new HasAtLeastminimumCharacters(16), new HasCapitalLetter(), new HasLowerCaseCharacter(), new HasNumericCharacter(), new HasUnderscoreCharacter()];

            var result = new  PasswordValidatorClass(rules).ValidatePassword(password);

            result.ShouldBe(false);
        }

        [Test]
        public void allow_when_password_satisfy_all_restrinctions() {
            var password = "HOL_AMUNDOTecEMOSLETRAS22JAAJA";
            List<ValidationRule> rules = [ new HasAtLeastminimumCharacters(16), new HasCapitalLetter(), new HasLowerCaseCharacter(), new HasNumericCharacter(), new HasUnderscoreCharacter()];

            var result = new  PasswordValidatorClass(rules).ValidatePassword(password);

            result.ShouldBe(true);
        }



}