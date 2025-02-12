using PasswordValidator.ValidationRules;
namespace PasswordValidator
{

    public class FirstPasswordValidator : IPasswordValidator{
        public bool ValidatePassword(string password){

            List<ValidationRule> rules = [new HasAtLeast8Characters(), new HasAtLeast8Characters(), new HasCapitalLetter(), new HasNumericCharacter(), new HasUnderscoreCharacter()];
            
            return rules.All(rule => rule.Validate(password));
        }
    }
}