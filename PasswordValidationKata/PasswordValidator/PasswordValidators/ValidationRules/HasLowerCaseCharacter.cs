namespace PasswordValidator.ValidationRules;
public class HasLowerCaseCharacter : ValidationRule
{

    public bool Validate(string password)
    {
        return password.Any(char.IsLower);
    }
    
}
