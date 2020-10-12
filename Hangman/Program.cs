using System;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {

            var wrongLetter = new char[10];
            string rightAnswer = "MAURITZ";
            char[] rightAswerA = new char[rightAnswer.Length]; 
            int numberOfGuesses = 10;
            char[] rightGuesses = new char[] {'_','_','_','_','_','_','_'};

            bool correctGuess = false;
            char guess;

            rightAswerA = rightAnswer.ToCharArray();

            
            

            do
            {
                foreach (var item in rightGuesses)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Enter your guess: ");
                guess = char.Parse(Console.ReadLine());
                if (rightAnswer.Contains(guess))
                {
                    rightGuesses[rightAnswer.IndexOf(guess)] = guess;
                    Console.WriteLine($"{guess} is correct");
                }

                else
                {
                    wrongLetter[numberOfGuesses -1] = guess;
                    Console.WriteLine($"{guess} is wrong");
                    numberOfGuesses--;

                }
                Console.WriteLine($"You have {numberOfGuesses} guesses left");
                if (rightAswerA.SequenceEqual(rightGuesses))
                {
                    correctGuess = true;
                    Console.WriteLine("You win");

                }
                

            } while (numberOfGuesses > 0 && correctGuess==false);
        }
    }
}
