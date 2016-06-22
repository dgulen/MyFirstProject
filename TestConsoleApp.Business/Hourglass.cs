using System;

namespace TestConsoleApp.Business
{
    class Hourglass
    {
        /// <summary>
        /// get hourglass size from user
        /// </summary>
        /// <returns>hourglass size</returns>
        public static int GetHourglassNumber()
        {
            Console.WriteLine("Case 2");
            Console.WriteLine("2. secenek secildi, kum saati ekrana yazılacak");

            Boolean loop = true;
            int number;

            while (loop)
            {
                Console.WriteLine("1 ile 80 arasında bir sayı giriniz:");
                var userInput = Console.ReadLine();

                while (!Int32.TryParse(userInput, out number))
                {
                    Console.WriteLine("Not a valid number, try again.");
                    userInput = Console.ReadLine();
                }

                if (number <= 80 && number >= 1)
                {
                    loop = false;
                    return number;
                }

                else
                {
                    Console.WriteLine("Geçersiz giriş, tekrar deneyiniz.");
                }
            }
            return 0;
        }

        /// <summary>
        /// Print hourglass shape with given input number
        /// </summary>
        /// <param name="n">size of hourglass</param>

        public static void PrintHourGlass(int n)
        {
            for (int row = 0; row < n; row++)
            {
                if (n % 2 == 0)
                {
                    if (row == n / 2)
                        row++;
                }

                int starCount = Math.Abs(n - row * 2 - 1) + 1;

                for (int c = 0; c < n - starCount; c++)
                    Console.Write(" ");

                for (int c = 0; c < starCount; c++)
                    Console.Write("* ");

                Console.WriteLine();
            }
        }
    }
}
