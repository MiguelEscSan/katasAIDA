using PasswordValidator.ValidationRules;
namespace PasswordValidator.Tests;

public class FirstPasswordValidatorShould {

    IPasswordValidator sut;
    

    [SetUp]
    public void SetUp() {
        //  List<ValidationRule> rules = [ new HasAtLeastminimumCharacters(8), new HasCapitalLetter(), new HasLowerCaseCharacter(), new HasNumericCharacter(), new HasUnderscoreCharacter()];
        List<Func<string, bool>> rules = new List<Func<string, bool>>() {RulesFunctions.HasCapitalLetter,RulesFunctions.HasLowerCaseCharacter,RulesFunctions.HasNumericCharacter, RulesFunctions.HasUnderscoreCharacter,RulesFunctions.HasAtLeastMinimunCharacters(8)};
        sut = new PasswordValidatorClass(rules);
    }

    [Test]
    public void not_allow_when_pass_is_less_than_8_characters_and_the_first_validator_is_used() {
       var password = "123456";
        
       var result = sut.ValidatePassword(password);

        result.ShouldBe(false);
        
    }

    [Test]
    public void not_allow_when_password_not_contains_a_capital_letter_and_the_first_validator_is_used(){
        var password = "amorzart";

        var result = sut.ValidatePassword(password);

        result.ShouldBe(false);
    }

    [Test]
    public void not_allow_when_password_not_contains_lower_case_and_the_first_validator_is_used(){
        var password = "AAAAAAAAAAAA";

        var result = sut.ValidatePassword(password);

        result.ShouldBe(false);
    }

   [Test]
   public void not_allow_when_password_not_contains_a_numeric_character_and_the_first_validator_is_used() {
        var password = "AAAAAAaaaaa";

        var result = sut.ValidatePassword(password);

        result.ShouldBe(false);
   }

   [Test]
    public void not_allow_when_password_not_contains_underscore_character_and_the_first_validator_is_used() {
        var password = "AAAAAAaaaaa9";

        var result = sut.ValidatePassword(password);

        result.ShouldBe(false);
    }

    [Test]
    public void not_allow_when__all_rules_are_valid_except_number_rule_first_validator_is_used(){
        var password = "Holaquetal_";

        var result = sut.ValidatePassword(password);

        result.ShouldBe(false);
    }

    [Test]
    public void give_true_when_password_is_valid_and_the_first_validator_is_used() {
        var password = "A_23aaa_4Fwwe";

        var result = sut.ValidatePassword(password);

        result.ShouldBe(true);
    }

}

