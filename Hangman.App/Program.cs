using System;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        static bool _gameOver = false; 
        static GuessResult result;
        static Hangman h = new Hangman("MAMMAS", 6);
        static bool printBlank = true;
        static void Main(string[] args)
        {
            while (!_gameOver)
            {
                PrintHangman(h.getCurrentHangman()); 
                PrintGuessesLeft(h.NrOfGuesses); 
                PrintYourGuesses(h.getGuessedLetters()); 
                PrintMessage(result);                            
                CollectUserInput();
                WinOrLose(h);
            }
        }

        private static void CollectUserInput()
        {
            Console.Write(" Enter your guess: ");
            result = h.Guess(Console.ReadLine().ToUpper());
            Console.Clear();
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

        public static void WinOrLose(Hangman h)  
        {
            if (h.CheckWin())
            {
                _gameOver = true;
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
            if ((!_gameOver) && (h.CheckLoose()))
            {
                _gameOver = true;
                Console.Clear();
                Console.SetCursorPosition(10, 2);
                Console.WriteLine("You lost");
                Console.Write("\n The correct word is \"");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(h.SecretWord);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\", better luck next time ;)");
                Console.WriteLine("\n");
                Console.Beep();
                Console.Beep();
            }
        }

        public static void PrintGuessesLeft(int numberOfGuesses)  
        {
            Console.WriteLine($" You have {numberOfGuesses} guesses left");
        }

        public static void PrintHangman(List<char> currentHangman)
        {
            Console.Title = "Hangman - [TEAM 1]";
            Console.SetCursorPosition(6, 2);
            foreach (var item in currentHangman)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(item + " ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
        }

        public static void PrintYourGuesses(List<char> guessedLetter)  
        {
            Console.Write(" Your guesses: ");
            Console.Write("[ ");
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (char item in guessedLetter)
            { 
                Console.Write(item + " ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");
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
            Console.Write(" Message: ");
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
