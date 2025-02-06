

/*
 * Escribe un programa que muestre por consola (con un print) los
 * números de 1 a 100 (ambos incluidos y con un salto de línea entre
 * cada impresión), sustituyendo los siguientes:
 * - Múltiplos de 3 por la palabra "fizz".
 * - Múltiplos de 5 por la palabra "buzz".
 * - Múltiplos de 3 y de 5 a la vez por la palabra "fizzbuzz".
 */
 
 namespace FizzBuzz;

 
 public class FizzBuzzClass
{
    public  string FizzBuzz(int numberLine){

        
        if(numberLine<0) {

            if(numberLine % 3 == 0 && numberLine%5 == 0){
                return "BuzzFizz";
            }

            if(numberLine%3 == 0){
                return "Buzz";
            }

            if(numberLine%5 == 0){
                return "Fizz";
            } 

        
        } else {

            if(numberLine % 3 == 0 && numberLine%5 == 0){
                return "FizzBuzz";
            }

            if(numberLine%3 == 0){
                return "Fizz";
            }

            if(numberLine%5 == 0){
                return "Buzz";
            }
        }
        
        return "";
    }
}

