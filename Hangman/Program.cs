using System;
using System.Linq;

namespace Hangman
{
    class Program
    {

        // todo: template (+ en metod 1-5 rader lång)

        //static void Main(string[] args)
        //{
        //    // En rad kod

        //    while(...)
        //    {
        //        // Typ fyra rader kod
        //    }

        //}


        static void Main(string[] args)
        {

            string rightAnswer = "MAMMA";
            int numberOfGuesses = 10;
            char[] rightAnswerA = new char[rightAnswer.Length]; // todo: namngivning
            var guessedLetter = new char[numberOfGuesses + rightAnswerA.Length];
            int numberOfGuessesAll = 0;


            char[] rightGuesses = new char[rightAnswer.Length];

            bool correctGuess = false;

            rightAnswerA = rightAnswer.ToCharArray();
            CreateHangman(rightAnswerA, rightGuesses);

            do
            {

                PrintHangman(rightGuesses);

                Console.WriteLine("Enter your guess: ");

                string input = Console.ReadLine().ToUpper();  // steg 1


                while (!CheckUserInput(input, guessedLetter))
                {
                    input = Console.ReadLine().ToUpper();

                }
                char guess = char.Parse(input);

                if (rightAnswer.Contains(guess))
                {
                    for (int i = 0; i < rightAnswerA.Length; i++)
                    {
                        if (rightAnswerA[i] == guess)
                            rightGuesses[i] = guess;
                    }


                }

                else
                {
                    //Console.WriteLine($"{guess} is wrong");
                    numberOfGuesses--;

                }
                guessedLetter[numberOfGuessesAll] = guess;
                numberOfGuessesAll++;

                Console.Clear();
                Console.WriteLine($"You have {numberOfGuesses} guesses left");
                PrintYourGuesses(guessedLetter);
                if (rightAnswerA.SequenceEqual(rightGuesses))
                {
                    correctGuess = true;
                    Console.Write("The hidden word is: ");


                    PrintHangman(rightGuesses);

                    Console.WriteLine();
                    Console.WriteLine("You win");

                }


            } while (numberOfGuesses > 0 && !correctGuess);
            if (!correctGuess)
            {
                Console.WriteLine("You lost");
            }

        }

        public static void ReadAndCalculateGuesses()
        {

        }

        public static void CreateHangman(char[] rightAnswerA, char[] rightGuesses)
        {
            for (int i = 0; i < rightAnswerA.Length; i++)
            {
                rightGuesses[i] = '_';
            }
        }
        public static void PrintHangman(char[] rightGuesses)
        {
            foreach (var item in rightGuesses)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(item + " ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");

        }

        public static void PrintYourGuesses(char[] guessedLetter)
        {
            Console.Write("Your guesses: ");

            foreach (var item in guessedLetter)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(item + " ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

        }

        public static bool CheckUserInput(string input, char[] guessedLetter)
        {
            if (input.Length != 1)
            {
                Console.WriteLine("Invalid input, enter only one character!");
                return false;
            }
            char ParsedGuess = char.Parse(input);
            bool IsLetter = char.IsLetter(ParsedGuess);

            if (!IsLetter)
            {
                Console.WriteLine("Invalid input, use letters only!");
                return false;
            }
            if (guessedLetter.Contains(ParsedGuess))
            {
                Console.WriteLine("You have already guessed this letter!");
                return false;
            }
            return true;
        }

    }
}
