namespace PasswordValidator.ValidationRules;

public class HasNumericCharacter : ValidationRule
{
    public bool Validate(string password)
    {
        return password.Any(char.IsNumber);
    }
    
}
