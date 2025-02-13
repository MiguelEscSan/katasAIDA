using PasswordValidator.ValidationRules;
namespace PasswordValidator
{

    public class PasswordValidatorClass : IPasswordValidator{

        List<ValidationRule> rules;

        public PasswordValidatorClass(List<ValidationRule> rules) {
            this.rules = rules;
        }

        public bool ValidatePassword(string password){
            return this.rules.All(rule => rule.Validate(password));
        }
    }
}