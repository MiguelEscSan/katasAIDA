namespace PasswordValidator.ValidationRules;

public class RulesFunctions {
   public static Func<string, bool> HasAtLeastMinimunCharacters(int MinLength) {
    return (password) => password.Length >= MinLength;
    }

    public static Func<string,bool> HasCapitalLetter = (password) =>  password.Any(char.IsUpper);

    public static Func<string,bool> HasLowerCaseCharacter =(password) => password.Any(char.IsLower);

    public static Func<string,bool> HasNumericCharacter = (password) => password.Any(char.IsNumber);

    public static Func<string,bool> HasUnderscoreCharacter = (password) =>  password.Contains('_');
}