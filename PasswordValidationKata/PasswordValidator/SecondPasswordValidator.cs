
namespace PasswordValidator
{

    public class SecondPasswordValidator : IPasswordValidator{

        public bool ValidatePassword(string password){
            bool isValid = true;

            if(password.Length < 6) return false;

            return isValid;
        }

    }
}