using Shouldly;

namespace FizzBuzz
{
    public class FizzBuzzShould
    {
      
      
        [Test]
        public void GivenANumberDivisableByThreeShouldGiveFizz()
        {
            var number = 3;
            var expected  = "Fizz";

            var result = new FizzBuzzClass().FizzBuzz(number);

            result.ShouldBe(expected);
        }
    }
}