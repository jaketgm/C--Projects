/******************************************************************************
 * @author Jake Brockbank
 * Dec 2nd, 2023 (Revitalized)
 * Calculate the factorial of a number.
******************************************************************************/
namespace Factorial
{
    /******************************************************************************
     * Class: Program: 
     * 
     * - Calculates the factorial of a number.
     *
     * Input: None.
     *
     * Output: Factorial of said number.
     *
    ******************************************************************************/
    class Program
    {
        /******************************************************************************
         * Method: Main: 
         * 
         * - The main method of the program.
         *
         * Input: None.
         *
         * Output: None.
         *
        ******************************************************************************/
        static void Main()
        {
            Console.Write("Input a number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.Write($"The Factorial of {num} is: {CalculateFactorial(num)}\n");
        }

        /******************************************************************************
         * Method: CalculateFactorial: 
         * 
         * - Takes an integer num as input and returns the factorial of that number 
         * as a long. The factorial of a number is the product of all positive 
         * integers up to that number. For instance, the factorial of 
         * 5 is 5 x 4 x 3 x 2 x 1. This method handles special cases for 0 and 1, 
         * where the factorial is 1, and then calculates the factorial for any 
         * other number by multiplying all integers from 2 up to num. The use of 
         * long for result allows the method to handle larger factorial values 
         * without integer overflow.
         *
         * Input: int num.
         *
         * Output: Factorial of number.
         *
        ******************************************************************************/
        static long CalculateFactorial(int num)
        {
            if (num == 0 || num == 1) return 1;

            long result = 1;
            for (int i = 2; i <= num; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}