using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static bool GameOver = false;
        static GuessResult result;
        static Hangman h = new Hangman("MAMMAS", 10);
        static bool printBlank = true;
        
        // OO: Nice method :)
        // OO: Your next step is to create tests for Hangman
        static void Main(string[] args)
        {

            
            h.CreateCurrentHangman();
            
            //PrintHangman(h.getCurrentHangman());
            //PrintGuessesLeft(h.getNrOfGuesses());

            while (!GameOver)
            {
                // Nytt yusri
                Console.SetCursorPosition(6, 2);
                PrintHangman(h.getCurrentHangman()); //     -------
                PrintGuessesLeft(h.getNrOfGuesses()); // gissningar kvar
                PrintYourGuesses(h.getGuessedLetters()); // gissade bokstäver
                Console.Write(" Message: "); 
                PrintMessage(result);
                Console.Write(" Enter your guess: ");
                
                 result = h.Guess(Console.ReadLine().ToUpper());
                //PrintMessage(result);
                Console.Clear();

                WinOrLose(h);
                //if (!GameOver)
                //{
                //    PrintGuessesLeft(h.getNrOfGuesses());
                //}

            }




        }

        // Yusri- Kan flyttas till core.
        public static bool ValidationCheck(GuessResult result)
        {
            if (result == GuessResult.InvalidGuess ||
                    result == GuessResult.IncorrectGuess ||
                    result == GuessResult.AlreadyGuessed)
            {
                return true;
            }
            else
                return false;
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

        public static void PrintYourGuesses(List<char> guessedLetter)  // Print out all guesses
        {
            Console.Write(" Your guesses: ");

            foreach (char item in guessedLetter)
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
            Console.ForegroundColor = ConsoleColor.Red;
            switch (type)
            {
                case GuessResult.InvalidGuess:
                    Console.WriteLine(" Invalid input!");
                    break;
                case GuessResult.IncorrectGuess:
                    Console.WriteLine(" Incorrect guess!");
                    break;
                case GuessResult.AlreadyGuessed:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(" You have already guessed this letter!");
                    Console.ResetColor();
                    break;
            }
            Console.ResetColor();
        }

        public static void PrintMessage(GuessResult result)
        {
            
            if (ValidationCheck(result))
            {
                PrintInvalidMessage(result);
            }
            
            else if (printBlank)
            {
                    Console.WriteLine(" ");
                    printBlank = false;           
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct guess!");
                Console.ResetColor();
            }

                
        }
    }
}
