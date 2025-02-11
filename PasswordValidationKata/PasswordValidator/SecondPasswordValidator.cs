
namespace PasswordValidator
{

    public class SecondPasswordValidator : IPasswordValidator{

        public bool ValidatePassword(string password){
            bool isValid = true;

            if(password.Length < 6) return false;

            if(!password.Any(char.IsLower)) return false;

            if(!password.Any(char.IsUpper)) return false;

            isValid = PasswordValidatorHelper.PasswordHasANumericCharacter(password);

            return isValid;
        }
    }
}