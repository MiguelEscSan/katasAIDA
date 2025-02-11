
namespace PasswordValidator
{
        public class PasswordValidatorContext {

        IPasswordValidator passwordValidator;

        public PasswordValidatorContext( IPasswordValidator passwordValidator) {
            this.passwordValidator = passwordValidator;
        }

        public bool ValidatePassword(string password) {
            return passwordValidator.ValidatePassword(password);
        }
    }
}