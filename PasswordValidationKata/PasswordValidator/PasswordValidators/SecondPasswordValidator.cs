
namespace PasswordValidator
{

    public class SecondPasswordValidator : IPasswordValidator{

        public bool ValidatePassword(string password){

            if(password.Length < 6) return false;

            if(!password.Any(char.IsLower)) return false;

            if(!password.Any(char.IsUpper)) return false;

            return PasswordValidatorHelper.PasswordHasANumericCharacter(password);

        }
    }
}