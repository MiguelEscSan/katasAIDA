namespace PasswordValidator.ValidationRules;
public class HasAtLeastminimumCharacters : ValidationRule
{

    int MinimumPasswordLength;

    public HasAtLeastminimumCharacters(int MinimumPasswordLength) {
        this.MinimumPasswordLength = MinimumPasswordLength;
    }
    public bool Validate(string password)
    {
        return password.Length >= this.MinimumPasswordLength;
    }
}