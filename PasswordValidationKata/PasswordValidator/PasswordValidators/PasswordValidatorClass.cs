using PasswordValidator.ValidationRules;
namespace PasswordValidator
{

    public class PasswordValidatorClass : IPasswordValidator{

        // List<ValidationRule> rules;

        // public PasswordValidatorClass(List<ValidationRule> rules) {
        //     this.rules = rules;
        // }

        // public bool ValidatePassword(string password){
        //     return this.rules.All(rule => rule.Validate(password));
        // }

        List<Func<string,bool>> rules ;

        public PasswordValidatorClass(List<Func<string,bool>> rules){
            this.rules = rules;
        }
        public bool ValidatePassword(string password){
            return this.rules.All(rule => rule(password));
        }
    }
}