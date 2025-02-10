using FluentAssertions;

namespace PasswordValidator.Tests;

public class PasswordValidatorShould {

    PasswordValidator sut;

    [SetUp]
    public void SetUp() {
        sut = new PasswordValidator();
    }

    [Test]
    public void not_allow_when_pass_is_less_than_8_characters () {
       var password = "123456";
        
       var result = sut.ValidatePassword(password);

        result.Should().BeFalse();
    }

    [Test]
    public void not_allow_when_password_not_contains_a_capital_letter(){
        var password = "amorzart";

        var result = sut.ValidatePassword(password);

        result.Should().BeFalse();
    }

    [Test]
    public void not_allow_when_password_not_contains_lower_case(){
        var password = "AAAAAAAAAAAA";

        var result = sut.ValidatePassword(password);

        result.Should().BeFalse();
    }

   [Test]
   public void not_allow_when_password_not_contains_a_numeric_character() {
        var password = "AAAAAAaaaaa";

        var result = sut.ValidatePassword(password);

        result.Should().BeFalse();
   }

   [Test]
    public void not_allow_when_password_not_contains_underscore_character() {
        var password = "AAAAAAaaaaa9";

        var result = sut.ValidatePassword(password);

        result.Should().BeFalse();
    }

    [Test]
    public void give_true_when_password_is_valid() {
        var password = "A_23aaa_4Fwwe";

        var result = sut.ValidatePassword(password);

        result.Should().BeTrue();
    }

}