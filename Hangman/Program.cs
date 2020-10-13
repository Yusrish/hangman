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
            /*
             todo:

             - fyllde i flera bokstäver i input
             - viss justering i gränsnittet (+färger)
             - konstigt tecken => invalid guess
             - gissa på samma bokstav flera gånger => visa bara en gång
             
             */

            string rightAnswer = "MAMMA";
            int numberOfGuesses = 10;
            char[] rightAswerA = new char[rightAnswer.Length]; // todo: namngivning
            var guessedLetter = new char[numberOfGuesses + rightAswerA.Length];
            int numberOfGuessesAll = 0;
            

            char[] rightGuesses = new char[rightAnswer.Length];

            bool correctGuess = false;
            //char guess; // todo: låt varablerna dö snabbt

            rightAswerA = rightAnswer.ToCharArray();
            for (int i = 0; i < rightAswerA.Length; i++)
            {
                rightGuesses[i] = '_';
            }

            do
            {

                PrintGuesses(rightGuesses);
                Console.WriteLine("\n");
                Console.WriteLine("Enter your guess: ");

                string input = Console.ReadLine().ToUpper();  // steg 1
                

                while (!CheckInputLength(input)) {
                    input = Console.ReadLine().ToUpper();
                }
                char guess = char.Parse(input);
                var result = char.IsLetter(guess);
                while (!CheckUserInput(input, guessedLetter, guess, result)) {
                    input = Console.ReadLine().ToUpper();
                     guess = char.Parse(input);
                     result = char.IsLetter(guess);

                }


                if (rightAnswer.Contains(guess))
                {
                    for (int i = 0; i < rightAswerA.Length; i++)
                    {
                        if (rightAswerA[i] == guess)
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
                Console.Write("Your guesses: ");
                foreach (var item in guessedLetter)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(item + " ");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                if (rightAswerA.SequenceEqual(rightGuesses))
                {
                    correctGuess = true;
                    Console.Write("The hidden word is: ");

                    foreach (var item in rightGuesses)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(item + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine();
                    Console.WriteLine("You win");

                }


            } while (numberOfGuesses > 0 && correctGuess == false);

        }

        public static void PrintGuesses(char[] rightGuesses)
        {

            foreach (var item in rightGuesses)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(item + " ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static bool CheckUserInput(string input, char[] guessedLetter, char guess, bool result)
        {
            bool isInputCorrect = false;
            

           
                if (input.Length != 1)
                {
                    Console.WriteLine("Invalid input, enter only one charecter!");
                }

                else if (!result)
                {
                    Console.WriteLine("Invalid input, use letters only!");
                }
                else if (guessedLetter.Contains(guess))
                {
                    Console.WriteLine("You have already guessed this letter!");
                }
                else
                    isInputCorrect = true;

                
 
            return isInputCorrect;

        }
        public static bool CheckInputLength(string input)
        {
            bool isInputCorrect = false;

            if (input.Length != 1)
            {
                Console.WriteLine("Invalid input, enter only one charecter!");
            }

            else
                isInputCorrect = true;



            return isInputCorrect;

        }
    }
}
