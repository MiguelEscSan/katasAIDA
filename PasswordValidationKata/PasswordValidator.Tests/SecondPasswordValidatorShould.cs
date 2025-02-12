using PasswordValidator.ValidationRules;
namespace PasswordValidator.Tests
{
    public class SecondPasswordValidatorShould
    {

        IPasswordValidator sut;

        [SetUp]
        public void SetUp() {
            // List<ValidationRule> rules = [ new HasAtLeastminimumCharacters(6), new HasCapitalLetter(), new HasLowerCaseCharacter(), new HasNumericCharacter()];
            List<Func<string, bool>> rules = new List<Func<string, bool>>() { RulesFunctions.HasCapitalLetter,RulesFunctions.HasLowerCaseCharacter, RulesFunctions.HasNumericCharacter, RulesFunctions.HasAtLeastMinimunCharacters(6)};
            sut = new PasswordValidatorClass(rules);
        }


        [Test]
        public void not_allow_when_pass_is_less_than_6_characters_and_the_second_validator_is_used() {
            var password = "12345";
            
            var result = sut.ValidatePassword(password);

            result.ShouldBe(false);
        }

        [Test]
        public void not_allow_when_password_not_contains_a_capital_letter_and_the_second_validator_is_used(){
            var password = "conduccion";

            var result = sut.ValidatePassword(password);

            result.ShouldBe(false);
        }

        [Test]
        public void not_allow_when_password_not_contains_lower_case_and_the_second_validator_is_used(){
            var password = "CONDUCCION";

            var result = sut.ValidatePassword(password);

            result.ShouldBe(false);
        }

        [Test]
        public void not_allow_when_password_not_contains_number_and_the_second_validator_is_used(){
            var password = "CONDUccion";

            var result = sut.ValidatePassword(password);

            result.ShouldBe(false);
        }

            [Test]
        public void give_true_when_password_is_valid_and_the_second_validator_is_used() {
            var password = "CONDUccion9";

            var result = sut.ValidatePassword(password);

            result.ShouldBe(true);
        }

    }
}