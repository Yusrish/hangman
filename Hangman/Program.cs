﻿using System;
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


        static void Main2(string[] args)
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
            char guess; // todo: låt varablerna dö snabbt

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
                    Console.Clear();
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

                Console.Clear();
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
