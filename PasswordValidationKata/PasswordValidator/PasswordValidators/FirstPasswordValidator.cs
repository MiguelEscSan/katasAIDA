
namespace PasswordValidator
{

    public class FirstPasswordValidator : IPasswordValidator{

        public bool ValidatePassword(string password){
            bool isValid = true;

            if(password.Length < 8) return false;

            if(!password.Any(char.IsLower)) return false;

            if(!password.Any(char.IsUpper)) return false;

            if(PasswordValidatorHelper.PasswordHasANumericCharacter(password) is false) return false;

            if(PasswordValidatorHelper.PasswordHasUnderscoreCharacter(password) is false) return false;

            return isValid;
        }
    }
}