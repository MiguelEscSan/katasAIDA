using PasswordValidator.ValidationRules;
namespace PasswordValidator
{

    public class FirstPasswordValidator : IPasswordValidator{
        public bool ValidatePassword(string password){
            
            if(new HasAtLeast8Characters().Validate(password) is false) return false;

            if(new HasLowerCaseCharacter().Validate(password) is false) return false;

            if(new HasCapitalLetter().Validate(password) is false) return false;

            if(new HasNumericCharacter().Validate(password) is false) return false;

            if(PasswordValidatorHelper.PasswordHasUnderscoreCharacter(password) is false) return false;

            return true;
        }
    }
}