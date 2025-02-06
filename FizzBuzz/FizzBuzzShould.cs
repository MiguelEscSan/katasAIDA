using Shouldly;

namespace FizzBuzz
{
    public class FizzBuzzShould
    {
      
      [Test]
      public void GiveAnEmptyStringWhenOneIsProvided(){
        var numberLine = 1;
        var expected = "";

        var result = new FizzBuzzClass().FizzBuzz(numberLine);

        result.ShouldBe(expected);

      }
      
        [Test]
        public void GiveFizzWhenANumberDivisableByThreeIsProvided()
        {
            var numberLine = 3;
            var expected  = "Fizz";

            var result = new FizzBuzzClass().FizzBuzz(numberLine);

            result.ShouldBe(expected);
        }

        [Test]
        
        public void GiveBuzzWhenANumberIsDivisableByFiveIsProvided() {
            var numberLine = 5;
            var expected = "Buzz";
            
            var result = new FizzBuzzClass().FizzBuzz(numberLine);

            result.ShouldBe(expected);
        }
    }
}