using PasswordValidator.ValidationRules;
namespace PasswordValidator;

public class SecondPasswordValidator : IPasswordValidator{

    List<ValidationRule> rules;
    public SecondPasswordValidator() {
        this.rules = [new HasAtLeastminimumCharacters(6), new HasLowerCaseCharacter(), new HasCapitalLetter(), new HasNumericCharacter()];
    }

    public bool ValidatePassword(string password){
        return this.rules.All(rule => rule.Validate(password));
    }
}