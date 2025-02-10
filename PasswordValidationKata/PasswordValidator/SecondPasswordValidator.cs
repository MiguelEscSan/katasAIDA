
namespace PasswordValidator
{

    public class SecondPasswordValidator : IPasswordValidator{

        public bool ValidatePassword(string password){
            bool isValid = true;

            if(password.Length < 6) return false;

            if(password.All(char.IsLower)) return false;

            if(password.All(char.IsUpper)) return false;

            isValid = PasswordValidatorHelper.PasswordHasANumericCharacter(password);
            System.Console.WriteLine(isValid);
            return isValid;
        }
    }
}