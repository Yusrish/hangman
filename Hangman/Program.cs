using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static bool GameOver = false;
        
        // OO: Nice method :)
        // OO: Your next step is to create tests for Hangman
        static void Main(string[] args)
        {

            var h = new Hangman("MAMMAS", 6);
            h.CreateCurrentHangman();
            PrintHangman(h.getCurrentHangman());
            PrintGuessesLeft(h.getNrOfGuesses());

            while (!GameOver)
            {
                Console.Write(" Enter your guess: ");
                GuessResult result = h.Guess(Console.ReadLine().ToUpper());

                if (result == GuessResult.InvalidGuess ||
                    result == GuessResult.IncorrectGuess ||
                    result == GuessResult.AlreadyGuessed)
                {
                    PrintInvalidMessage(result);
                }
                else { 
                    PrintHangman(h.getCurrentHangman());                                
                }
                WinOrLose(h);
                if (!GameOver)
                {
                    PrintGuessesLeft(h.getNrOfGuesses());
                }
                
            }
            


            
        }
        public static void WinOrLose(Hangman h)  // Prints out win or lost with the correct word
        {
            if (h.CheckWin())
            {
                GameOver = true;
                Console.Clear();
                Console.SetCursorPosition(10, 2);
                Console.WriteLine("You win!!");
                Console.WriteLine();
                Console.Write(" The hidden word is: ");
                PrintHangman(h.getCurrentHangman());
                Console.Beep();
                Console.Beep();
            }
            //Group5 - isDone is not changed from false so will always be false. it shoudld be enough with "checkLoose"
            if ((!GameOver) && (h.CheckLoose()))
            {
                GameOver = true;
                Console.Clear();
                Console.SetCursorPosition(10, 2);
                Console.WriteLine("You lost");
                Console.Write("\n The correct word is \"");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(h.getSecretWord());
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\", better luck next time ;)");
                Console.WriteLine("\n");
                Console.Beep();
                Console.Beep();
            }
        }

        
        public static void PrintGuessesLeft(int numberOfGuesses)  // Read user input
        {
            Console.WriteLine($" You have {numberOfGuesses} guesses left");          
        }

        public static void PrintHangman(List<char> currentHangman)  // Print out current hangman
        {
            foreach (var item in currentHangman)
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
            Console.Beep();
            switch (type)
            {
                case GuessResult.InvalidGuess:
                    Console.WriteLine(" Invalid input!");
                    break;
                case GuessResult.IncorrectGuess:                
                    Console.WriteLine(" Incorrect guess!");
                    break;
                case GuessResult.AlreadyGuessed:                
                    Console.WriteLine(" You have already guessed this letter!");
                    break;
            }
        }
    }
}
