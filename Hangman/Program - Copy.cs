using System;
using System.Linq;

namespace Hangman_copy
{
    class Program_copy
    {
        static string HiddenWord = "MAMMA";
        static char[] HiddenWord_Array;
        static int numberOfGuesses = 10;
        static char[] guessedLetters;
        static char[] CurrentHangman;
        static int IndexGuessedLetters = 0;
        static bool isDone = false;
        //static bool isCorrectGuess = false;
        static char CurrentGuess;

        static void Main_copy(string[] args)
        {

            Console.Title = "Hangman - By Team 1";
            Console.SetCursorPosition(10, 2);
            HiddenWord_Array = new char[HiddenWord.Length];
            guessedLetters = new char[numberOfGuesses + HiddenWord_Array.Length];
            CurrentHangman = new char[HiddenWord_Array.Length];
            HiddenWord_Array = HiddenWord.ToCharArray();

            CreateHangman(HiddenWord_Array, CurrentHangman);
            do
            {
                Console.SetCursorPosition(10, 2);
                PrintHangman(CurrentHangman);
                ReadAndCalculateGuesses(numberOfGuesses, guessedLetters);
                string input = Console.ReadLine().ToUpper();

                while (!CheckUserInput(input, guessedLetters))
                {
                    Console.Write(" Enter your guess: ");
                    input = Console.ReadLine().ToUpper();
                }
                CurrentGuess = char.Parse(input);
                UpdatePrintedHangman(CurrentGuess);


                guessedLetters[IndexGuessedLetters] = CurrentGuess;
                IndexGuessedLetters++;

                Console.Clear();
                WinOrLose();

            } while (numberOfGuesses > 0 && !isDone);
        }
        public static void WinOrLose()  // Prints out win or lost with the correct word
        {
            if (HiddenWord_Array.SequenceEqual(CurrentHangman))
            {
                isDone = true;
                Console.SetCursorPosition(10, 2);
                Console.WriteLine("You win!!");
                Console.WriteLine();
                Console.Write(" The hidden word is: ");
                PrintHangman(CurrentHangman);
                Console.Beep();
                Console.Beep();
            }
            if ((!isDone) && (numberOfGuesses == 0))
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

        public static void UpdatePrintedHangman(char guess)  // replace hangman underscore with correct letters
        {
            if (HiddenWord.Contains(guess)) // byter understreck med rätt bokstav
            {
                for (int i = 0; i < HiddenWord_Array.Length; i++)
                {
                    if (HiddenWord_Array[i] == guess)
                        CurrentHangman[i] = guess;
                }
            }
            else
            {
                numberOfGuesses--;
            }

        }

        public static void ReadAndCalculateGuesses(int numberOfGuesses, char[] guessedLetter)  // Read user input
        {

            Console.WriteLine($" You have {numberOfGuesses} guesses left");
            PrintYourGuesses(guessedLetter);
            Console.Write(" Enter your guess: ");

        }

        public static void CreateHangman(char[] rightAnswerA, char[] rightGuesses)   // store correct number of underscores in an array
        {
            for (int i = 0; i < rightAnswerA.Length; i++)
            {
                rightGuesses[i] = '_';
            }
        }
        public static void PrintHangman(char[] rightGuesses)  // Print out current hangman
        {
            foreach (var item in rightGuesses)
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

        public static bool CheckUserInput(string input, char[] guessedLetter)  // User input validations
        {
            if (input.Length != 1)
            {
                PrintInvalidMessage(1);                             
                return false;
            }
            char ParsedGuess = char.Parse(input);
            bool IsLetter = char.IsLetter(ParsedGuess);

            if (!IsLetter)
            {
                PrintInvalidMessage(2);
                return false;
            }
            if (guessedLetter.Contains(ParsedGuess))
            {
                PrintInvalidMessage(3);                
                return false;
            }
            return true;
        }

        public static void PrintInvalidMessage(int type)
        {
            switch(type)
            {
                case 1:
                    Console.Beep();
                    Console.WriteLine(" Invalid input, enter only one character!");
                    break;
                case 2:
                    Console.Beep();
                    Console.WriteLine(" Invalid input, use letters only!");
                    break;
                case 3:
                    Console.Beep();
                    Console.WriteLine(" You have already guessed this letter!");
                    break;
            }
        }
    }
}
