using System;

namespace TestConsoleApp.Business
{
    public class Operation
    {

        /// <summary>
        /// select the operation to perform 
        /// </summary>
        /// <param name="choice">int input from menu</param>

        public static void ExecuteOperation(int choice)
        {
            int number;

            switch (choice)
            {
                case 1:

                    number = Fibonacci.GetFibonacciNumber();

                    var fibSeries=Fibonacci.FibonacciNumberCalculation(number);
                    Console.WriteLine(fibSeries);

                    break;

                case 2:

                    number = Hourglass.GetHourglassNumber();

                    Hourglass.PrintHourGlass(number);
                      
                    break;

                case 3:

                    string city = City.GetString();

                    City.PrintWeather(city);

                    break;

                default:

                    Console.WriteLine("Gecersiz giris.");

                    break;

            }

            Console.ReadLine();

        }
    }
}
