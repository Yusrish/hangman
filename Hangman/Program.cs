using System;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {

            
            string rightAnswer = "MAMMA";
            int numberOfGuesses = 10;
            char[] rightAswerA = new char[rightAnswer.Length];
            var guessedLetter = new char[numberOfGuesses + rightAswerA.Length];
            int numberOfGuessesAll = 0;

            char[] rightGuesses = new char[rightAnswer.Length];

            bool correctGuess = false;
            char guess;

            rightAswerA = rightAnswer.ToCharArray();
            for (int i = 0; i < rightAswerA.Length; i++)
            {
                rightGuesses[i] = '_';           
            }   
            
            


            do
            {
                foreach (var item in rightGuesses)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Enter your guess: ");
                                
                guess = char.Parse(Console.ReadLine().ToUpper());
                var result = char.IsLetter(guess);
                
                if (!result) {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                else if (rightAnswer.Contains(guess))
                {
                    for (int i = 0; i < rightAswerA.Length; i++)
                    {
                        if (rightAswerA[i] == guess)
                            rightGuesses[i] = guess;
                    }                  
                    
                    Console.WriteLine($"{guess} is correct");
                }

                else
                {
                    Console.WriteLine($"{guess} is wrong");
                    numberOfGuesses--;

                }
                guessedLetter[numberOfGuessesAll] = guess;
                numberOfGuessesAll++;

                Console.WriteLine($"You have {numberOfGuesses} guesses left");
                foreach (var item in guessedLetter)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                if (rightAswerA.SequenceEqual(rightGuesses))
                {
                    correctGuess = true;
                    foreach (var item in rightGuesses)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                    Console.WriteLine("You win");

                }
                

            } while (numberOfGuesses > 0 && correctGuess==false);
        
            
            }
    }
}
