namespace PasswordValidator;

public class PasswordValidator {

    public bool ValidatePassword(string password){
        bool isValid = true;

        if(password.Length < 8) return false;

        if(password.All(char.IsLower)) return false;

        if(password.All(char.IsUpper)) return false;

        isValid = PasswordHasANumericCharacter(password);

        isValid = PasswordHasUnderscoreCharacter(password);

        return isValid;
    }

    public bool PasswordHasANumericCharacter(string password) {
        return (password.All(character => char.IsNumber(character) is true));
    } 

    public bool PasswordHasUnderscoreCharacter(string password) {
        return (password.Contains('_'));
    }

}