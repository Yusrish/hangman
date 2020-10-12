using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {

            var wrongLetter = new char[10];
            string rightAnswer = "MAURITZ";
            int numberOfGuesses = 10;

            bool correctGuess = false;
            char guess;

            do
            {
                Console.WriteLine("Enter your guess: ");
                guess = char.Parse(Console.ReadLine());
                if (rightAnswer.Contains(guess))
                {
                    Console.WriteLine($"{guess} is correct");
                }
                else
                {
                    wrongLetter[numberOfGuesses] = guess;
                    Console.WriteLine($"{guess} is wrong");
                }
                numberOfGuesses--;

            } while (numberOfGuesses > 0 && correctGuess==false);
        }
    }
}
