using PasswordValidator.ValidationRules;
namespace PasswordValidator
{

    public class FirstPasswordValidator : IPasswordValidator{

        List<ValidationRule> rules;

        public FirstPasswordValidator() {
            this.rules = [new HasAtLeastminimumCharacters(8), new HasLowerCaseCharacter(), new HasCapitalLetter(), new HasNumericCharacter(), new HasUnderscoreCharacter()];
        }

        public bool ValidatePassword(string password){
            return this.rules.All(rule => rule.Validate(password));
        }
    }
}