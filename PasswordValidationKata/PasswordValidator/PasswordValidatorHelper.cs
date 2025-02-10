namespace PasswordValidator
{
    public static class PasswordValidatorHelper
    {

        public static bool PasswordHasUnderscoreCharacter(string password) {
            return (password.Contains('_'));
        }
        public static bool PasswordHasANumericCharacter(string password) {
            return (password.All(character => char.IsNumber(character) is true));
        } 
        
    }
}