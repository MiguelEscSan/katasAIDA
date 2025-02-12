using PasswordValidator.ValidationRules;
namespace PasswordValidator
{

    public class FirstPasswordValidator : IPasswordValidator{
        public bool ValidatePassword(string password){
            

            // if(password.Length < 8) return false;
            if(new LengthValidationRule().Validate(password) is false) return false;

            if(!password.Any(char.IsLower)) return false;

            if(!password.Any(char.IsUpper)) return false;

            if(PasswordValidatorHelper.PasswordHasANumericCharacter(password) is false) return false;

            if(PasswordValidatorHelper.PasswordHasUnderscoreCharacter(password) is false) return false;

            return true;
        }
    }
}