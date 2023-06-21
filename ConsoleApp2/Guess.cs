using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class GuessingGame
    {
        public static void Play()
        {
            Console.WriteLine("Guessing Game !");
            string secretWord = "Nazal";
            string guess = "";

            for (int t = 9; t > 0; t--)
            {
                Console.WriteLine("Guess !");
                guess = Console.ReadLine();

                if (guess != secretWord)
                {
                    Console.WriteLine("You've got " + t + " chances left!");
                }
                else
                {
                    Console.WriteLine("You've guessed correctly");
                    return; // Exit the method if the guess is correct
                }
            }

            Console.WriteLine("You've run out of chances!");
        }
    }
}
