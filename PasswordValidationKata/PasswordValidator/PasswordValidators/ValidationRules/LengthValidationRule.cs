namespace PasswordValidator.ValidationRules;
public class LengthValidationRule : ValidationRule
{
    public bool Validate(string password)
    {
        return password.Length >= 8;
    }
}