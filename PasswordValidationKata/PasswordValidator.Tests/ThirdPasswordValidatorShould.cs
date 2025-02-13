using PasswordValidator.ValidationRules;
namespace PasswordValidator.Tests
{
    public class ThirdPasswordValidatorShould
    {

        IPasswordValidator sut;

        [SetUp]
        public void SetUp() {
            // List<ValidationRule> rules = [ new HasAtLeastminimumCharacters(16), new HasCapitalLetter(), new HasLowerCaseCharacter(), new HasUnderscoreCharacter()];
            List<Func<string, bool>> rules = new List<Func<string, bool>>() {     RulesFunctions.HasCapitalLetter,    RulesFunctions.HasLowerCaseCharacter,    RulesFunctions.HasNumericCharacter,     RulesFunctions.HasUnderscoreCharacter,     RulesFunctions.HasAtLeastMinimunCharacters(16)};
            sut = new PasswordValidatorClass(rules);
        }


        [Test]
        public void not_allowed_when_password_is_empty(){
            var password ="";

            var result = sut.ValidatePassword(password);
            
            result.ShouldBe(false);

        }

        [Test]
        public void not_allowed_when_password_has_less_than_sixteen_characters(){
            var password = "holaquetal";

            var result = sut.ValidatePassword(password);
            
            result.ShouldBe(false);

        }

        [Test]
        public void not_allowed_when_password_doesnt_have_upper_case(){
            var password = "holaquetalestosonm1asdecharacteres";

            var result = sut.ValidatePassword(password);
            
            result.ShouldBe(false);
        }

        [Test]
        public void not_allowed_when_password_doesnt_have_lowercase_characteres() {
            var password = "AAAAAAAAAAAAAAAAAAAAAAAA32_AAAAAAAAAAAAA";

            var result = sut.ValidatePassword(password);

            result.ShouldBe(false);
        }

        [Test]
        public void not_allowed_when_password_doesnt_have_underscore_charactere() {
            var password = "AAAAAAAAAAAAAAAAAAAAAaAA32AAAAAAAAAAAAA";

            var result = sut.ValidatePassword(password);

            result.ShouldBe(false);
        }

        [Test]
        public void allowed_when_password_satisfied_all_conditions() {
            var password = "AAAAAAasasdAAA32AAAAAAAAAAaAA32AAAA_AAAAAAAAA";

            var result = sut.ValidatePassword(password);

            result.ShouldBe(true);
        }

    }
}