using Shouldly;

namespace FizzBuzz
{
    public class FizzBuzzShould
    {
      
      [Test]
      public void GiveAnEmptyStringWhenOneIsProvided(){
        var number = 1;
        var expected = "";

        var result = new FizzBuzzClass().FizzBuzz(number);

        result.ShouldBe(expected);

      }
      
        [Test]
        public void GiveANumberDivisableByThreeShouldGiveFizz()
        {
            var number = 3;
            var expected  = "Fizz";

            var result = new FizzBuzzClass().FizzBuzz(number);

            result.ShouldBe(expected);
        }
    }
}