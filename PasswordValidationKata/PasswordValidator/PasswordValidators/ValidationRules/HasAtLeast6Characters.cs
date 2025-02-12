namespace PasswordValidator.ValidationRules;
public class HasAtLeast6Characters : ValidationRule
{
    public bool Validate(string password)
    {
        return password.Length >= 6;
    }
}