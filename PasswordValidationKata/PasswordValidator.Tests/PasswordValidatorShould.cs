using FluentAssertions;

namespace PasswordValidator.Tests;

public class PasswordValidatorShould {


    PasswordValidatorFactory sut;

    [SetUp]
    public void SetUp() {
        sut = new PasswordValidatorFactory();
    }


    [Test]
    public void not_allow_when_pass_is_less_than_8_characters_and_the_first_validator_is_used() {
       var password = "123456";
        
       var result = sut.getPasswordValidator(PasswordValidatorType.First).ValidatePassword(password);

        result.Should().BeFalse();
        
    }

    [Test]
    public void not_allow_when_password_not_contains_a_capital_letter_and_the_first_validator_is_used(){
        var password = "amorzart";

        var result = sut.getPasswordValidator(PasswordValidatorType.First).ValidatePassword(password);

        result.Should().BeFalse();
    }

    [Test]
    public void not_allow_when_password_not_contains_lower_case_and_the_first_validator_is_used(){
        var password = "AAAAAAAAAAAA";

        var result = sut.getPasswordValidator(PasswordValidatorType.First).ValidatePassword(password);

        result.Should().BeFalse();
    }

   [Test]
   public void not_allow_when_password_not_contains_a_numeric_character_and_the_first_validator_is_used() {
        var password = "AAAAAAaaaaa";

        var result = sut.getPasswordValidator(PasswordValidatorType.First).ValidatePassword(password);

        result.Should().BeFalse();
   }

   [Test]
    public void not_allow_when_password_not_contains_underscore_character_and_the_first_validator_is_used() {
        var password = "AAAAAAaaaaa9";

        var result = sut.getPasswordValidator(PasswordValidatorType.First).ValidatePassword(password);

        result.Should().BeFalse();
    }

    [Test]
    public void give_true_when_password_is_valid_and_the_first_validator_is_used() {
        var password = "A_23aaa_4Fwwe";

        var result = sut.getPasswordValidator(PasswordValidatorType.First).ValidatePassword(password);

        result.Should().BeTrue();
    }

    [Test]
    public void not_allow_when_pass_is_less_than_6_characters_and_the_second_validator_is_used() {
       var password = "12345";
        
       var result = sut.getPasswordValidator(PasswordValidatorType.Second).ValidatePassword(password);

        result.Should().BeFalse();
        
    }

    [Test]
    public void not_allow_when_password_not_contains_a_capital_letter_and_the_second_validator_is_used(){
        var password = "conduccion";

        var result = sut.getPasswordValidator(PasswordValidatorType.Second).ValidatePassword(password);

        result.Should().BeFalse();
    }

    [Test]
    public void not_allow_when_password_not_contains_lower_case_and_the_second_validator_is_used(){
        var password = "CONDUCCION";

        var result = sut.getPasswordValidator(PasswordValidatorType.Second).ValidatePassword(password);

        result.Should().BeFalse();
    }

    [Test]
    public void not_allow_when_password_not_contains_number_and_the_second_validator_is_used(){
        var password = "CONDUccion";

        var result = sut.getPasswordValidator(PasswordValidatorType.Second).ValidatePassword(password);

        result.Should().BeFalse();
    }
}

