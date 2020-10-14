using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static string HiddenWord = "MAMMA";
        static char[] HiddenWord_Array;
        static int numberOfGuesses = 10;
        static char[] guessedLetters;
        static char[] CurrentHangman;
        static int IndexGuessedLetters = 0;
        static bool isDone = false;
        static bool isCorrectGuess = false;
        static char CurrentGuess;

        static void Main(string[] args)
        {

            var h = new Hangman("MAMMAS", 3);
            h.CreateHangman();

            while (!isDone)
            {
                Console.Write(" Enter your guess: ");
                GuessResult result = h.Guess(Console.ReadLine().ToUpper());

                if (result == GuessResult.InvalidGuess ||
                    result == GuessResult.IncorrectGuess ||
                    result == GuessResult.AlreadyGuessed)
                {
                    PrintInvalidMessage(result);
                    continue;
                }
                PrintHangman(h.getCurrentHangman());
                WinOrLose(h);
            }
            


            /*
            Console.WriteLine($"Resultatet blev {result}");
            
            result = h.Guess("A");

            Console.WriteLine($"Resultatet blev {result}");

            result = h.Guess("A");

            Console.WriteLine($"Resultatet blev {result}");

            result = h.Guess("f");

            Console.WriteLine($"Resultatet blev {result}"); */

            //Console.Title = "Hangman - By Team 1";
            //Console.SetCursorPosition(10, 2);
            //HiddenWord_Array = new char[HiddenWord.Length]; 
            //guessedLetters = new char[numberOfGuesses + HiddenWord_Array.Length];
            //CurrentHangman = new char[HiddenWord_Array.Length];
            //HiddenWord_Array = HiddenWord.ToCharArray();

            //CreateHangman(HiddenWord_Array, CurrentHangman);
            //do
            //{
            //    Console.SetCursorPosition(10, 2);
            //    PrintHangman(CurrentHangman);
            //    ReadAndCalculateGuesses(numberOfGuesses, guessedLetters);
            //    string input = Console.ReadLine().ToUpper();

            //    while (!CheckUserInput(input, guessedLetters))
            //    {
            //        Console.Write(" Enter your guess: ");
            //        input = Console.ReadLine().ToUpper();
            //    }                
            //    CurrentGuess = char.Parse(input);
            //    UpdatePrintedHangman(CurrentGuess);


            //    guessedLetters[IndexGuessedLetters] = CurrentGuess;
            //    IndexGuessedLetters++;

            //    Console.Clear();
            //    WinOrLose();

            //} while (numberOfGuesses > 0 && !isDone);
        }
        public static void WinOrLose(Hangman h)  // Prints out win or lost with the correct word
        {
            if (h.CheckWin())
            {
                isDone = true;
                Console.SetCursorPosition(10, 2);
                Console.WriteLine("You win!!");
                Console.WriteLine();
                Console.Write(" The hidden word is: ");
                PrintHangman(h.getCurrentHangman());
                Console.Beep();
                Console.Beep();
            }
            if ((!isDone) && (h.CheckLoose()))
            {
                Console.SetCursorPosition(10, 2);
                Console.WriteLine("You lost");
                Console.Write("\n The correct word is \"");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(HiddenWord);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\", better luck next time ;)");
                Console.WriteLine("\n");
                Console.Beep();
                Console.Beep();
            }
        }

        

        public static void ReadAndCalculateGuesses(int numberOfGuesses, char[] guessedLetter)  // Read user input
        {

            Console.WriteLine($" You have {numberOfGuesses} guesses left");
            PrintYourGuesses(guessedLetter);
            Console.Write(" Enter your guess: ");

        }

        
        public static void PrintHangman(List<char> l)  // Print out current hangman
        {
            foreach (var item in l)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(item + " ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");

        }

        public static void PrintYourGuesses(char[] guessedLetter)  // Print out all guesses
        {
            Console.Write(" Your guesses: ");

            foreach (var item in guessedLetter)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(item + " ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

        }
               

        public static void PrintInvalidMessage(GuessResult type)
        {
            switch(type)
            {
                case GuessResult.InvalidGuess:
                    Console.Beep();
                    Console.WriteLine(" Invalid input!");
                    break;
                case GuessResult.IncorrectGuess:
                    Console.Beep();
                    Console.WriteLine(" Incorrect guess!");
                    break;
                case GuessResult.AlreadyGuessed:
                    Console.Beep();
                    Console.WriteLine(" You have already guessed this letter!");
                    break;
            }
        }
    }
}
