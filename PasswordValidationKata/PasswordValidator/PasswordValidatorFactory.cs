namespace PasswordValidator;
    public class PasswordValidatorFactory {
        public IPasswordValidator getPasswordValidator (PasswordValidatorType passwordValidatorType){
            switch (passwordValidatorType){
                case PasswordValidatorType.First :
                    return new FirstPasswordValidator();
                case PasswordValidatorType.Second :
                    return new SecondPasswordValidator();

                default : 
                    throw new NotSupportedException();


            }
        }
    }
