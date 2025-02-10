
namespace PasswordValidator
{

    public class FirstPasswordValidator : IPasswordValidator{

        public bool ValidatePassword(string password){
            bool isValid = true;

            if(password.Length < 8) return false;

            if(password.All(char.IsLower)) return false;

            if(password.All(char.IsUpper)) return false;

            isValid = PasswordValidatorHelper.PasswordHasANumericCharacter(password);


            isValid &= PasswordValidatorHelper.PasswordHasUnderscoreCharacter(password);

            return isValid;
        }

    }
}