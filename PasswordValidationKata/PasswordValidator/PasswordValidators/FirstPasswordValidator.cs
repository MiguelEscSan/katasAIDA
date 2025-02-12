using PasswordValidator.ValidationRules;
namespace PasswordValidator
{

    public class FirstPasswordValidator : IPasswordValidator{
        public bool ValidatePassword(string password){
            
            if(new LengthValidationRule().Validate(password) is false) return false;

            if(new IsLowerValidationRule().Validate(password) is false) return false;

            if(new UpperValidationRule().Validate(password) is false) return false;

            if(PasswordValidatorHelper.PasswordHasANumericCharacter(password) is false) return false;

            if(PasswordValidatorHelper.PasswordHasUnderscoreCharacter(password) is false) return false;

            return true;
        }
    }
}