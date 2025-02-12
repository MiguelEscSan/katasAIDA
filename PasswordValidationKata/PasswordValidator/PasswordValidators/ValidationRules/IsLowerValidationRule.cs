namespace PasswordValidator.ValidationRules;
public class IsLowerValidationRule : ValidationRule
{

    public bool Validate(string password)
    {
        return password.Any(char.IsLower);
    }
    
}
