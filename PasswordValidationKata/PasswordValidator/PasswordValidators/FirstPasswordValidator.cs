using PasswordValidator.ValidationRules;
namespace PasswordValidator
{

    public class FirstPasswordValidator : IPasswordValidator{

        List<ValidationRule> rules;

        public FirstPasswordValidator() {
            this.rules = [new HasAtLeast8Characters(), new HasAtLeast8Characters(), new HasCapitalLetter(), new HasNumericCharacter(), new HasUnderscoreCharacter()];
        }

        public bool ValidatePassword(string password){
            return this.rules.All(rule => rule.Validate(password));
        }
    }
}