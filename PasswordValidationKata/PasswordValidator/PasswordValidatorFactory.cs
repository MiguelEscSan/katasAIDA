namespace PasswordValidator;
    public class PasswordValidatorFactory {
        public IPasswordValidator getPasswordValidator (PasswordValidatorType passwordValidatorType){
            switch (passwordValidatorType){
                case PasswordValidatorType.first :
                    return new FirstPasswordValidator();
                case PasswordValidatorType.second :
                    return new SecondPasswordValidator();

                default : throw new NotSupportedException();


            }
        }
    }
