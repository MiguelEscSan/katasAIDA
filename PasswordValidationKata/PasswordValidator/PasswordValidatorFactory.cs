namespace PasswordValidator;
    public class PasswordValidatorFactory {
        public IPasswordValidator getPasswordValidator (PasswordValidatorType passwordValidatorType){
            switch (passwordValidatorType){
                case PasswordValidatorType.first :
                    return new PasswordValidator();
                case PasswordValidatorType.second :
                    return new SecondPasswordValidator();

                default : throw new NotSupportedException();


            }
        }
    }
