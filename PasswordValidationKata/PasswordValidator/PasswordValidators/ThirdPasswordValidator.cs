using PasswordValidator.ValidationRules;
namespace PasswordValidator;

public class ThirdPasswordValidator: IPasswordValidator{
    List<ValidationRule> rules;
    public ThirdPasswordValidator() {
        this.rules = [new HasAtLeastminimumCharacters(16), new HasLowerCaseCharacter(), new HasCapitalLetter(), new HasUnderscoreCharacter()];
    }

    public bool ValidatePassword(string password){
        return this.rules.All(rule => rule.Validate(password));
    }
}
