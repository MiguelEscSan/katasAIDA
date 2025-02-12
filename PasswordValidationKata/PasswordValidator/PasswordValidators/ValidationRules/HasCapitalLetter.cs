namespace PasswordValidator.ValidationRules;
public class HasCapitalLetter : ValidationRule
{
    public bool Validate(string password)
    {
        return password.Any(char.IsUpper);
    }
}