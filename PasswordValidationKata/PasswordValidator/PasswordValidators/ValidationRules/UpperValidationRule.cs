namespace PasswordValidator.ValidationRules;
public class UpperValidationRule : ValidationRule
{
    public bool Validate(string password)
    {
        return password.Any(char.IsUpper);
    }
}