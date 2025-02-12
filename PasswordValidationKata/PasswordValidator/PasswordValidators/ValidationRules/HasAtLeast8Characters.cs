namespace PasswordValidator.ValidationRules;
public class HasAtLeast8Characters : ValidationRule
{
    public bool Validate(string password)
    {
        return password.Length >= 8;
    }
}