namespace PasswordValidator.ValidationRules;
public class HasUnderscoreCharacter : ValidationRule
{
    public bool Validate(string password)
    {
        return password.Contains('_');
    }
}
