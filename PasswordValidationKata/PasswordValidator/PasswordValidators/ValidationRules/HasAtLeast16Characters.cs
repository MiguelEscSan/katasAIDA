namespace PasswordValidator.ValidationRules;
public class HasAtLeast16Characters : ValidationRule
{
    public bool Validate(string password)
    {
        return password.Length >= 16;
    }
}