namespace PasswordValidator;
    public class PasswordValidatorFactory {
        public IPasswordValidator getPasswordValidator (PasswordValidatorType passwordValidatorType){
            switch (passwordValidatorType){
                case PasswordValidatorType.first :
                    return new PasswordValidator();

                default : throw new NotSupportedException();


            }
        }
    }
