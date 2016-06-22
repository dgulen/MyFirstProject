using System;
using System.Numerics;

namespace TestConsoleApp.Business
{
    class Fibonacci
    {
        
        /// <summary>
        /// get number from user to calculate
        /// </summary>
        /// <returns>fibonacci number to be calculated</returns>

        public static int GetFibonacciNumber()
        {
            Console.WriteLine("1. secenek secildi, fibonacci sayısı hesaplanacak");
            Console.WriteLine("Fibonacci sayisi hesaplanacak sayiyi giriniz:");

            var userInput = Console.ReadLine();
            int number; ;

            while (!Int32.TryParse(userInput, out number))
            {
                Console.WriteLine("Not a valid number, try again. ");
                userInput = Console.ReadLine();
            }

            return number;

        }

        /// <summary>
        /// calculate fibonacci number of given number
        /// </summary>
        /// <param name="fibonacciNumber">numberi fibonacci number to be calculated</param>
        /// <returns>n th fibonacci number</returns>

        public static BigInteger FibonacciNumberCalculation(int fibonacciNumber)
        {

            BigInteger a = 0;
            BigInteger b = 1;

            for (int i = 0; i < fibonacciNumber; i++)
            {

                BigInteger temp = a;
                a = b;
                b = temp + b;

            }

            return a;

        }   
    }
}
