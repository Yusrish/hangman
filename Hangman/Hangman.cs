using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class Hangman
    {
        //Group5 - Do you really need both _secretWord and _secretWord_Array? can you combine these?
        private string _secretWord;

        // OO: You can remove the definition here and move it to "UpdateCurrentHangman"
        private char[] _secretWord_Array; 

        private int _numberOfGuesses;
        private List<char> _guessedLetters = new List<char>();
        private List<char> _currentHangman = new List<char>();
        private char parsedGuess;
        public string guess;
 //OO: Change name. E.g to "_maskedWord" or similair
        public Hangman(string secretWord, int nrOfGuesses)
        {
            _secretWord = secretWord;
            _secretWord_Array = _secretWord.ToCharArray();
            _numberOfGuesses = nrOfGuesses;
            
        }
        // OO: Naming (GetSecretWord)
        public string getSecretWord()
        {
            return _secretWord;
        }

        public List<char> getGuessedLetters()
        {
            return _guessedLetters;
        }
        public int getNrOfGuesses()
        {
            return _numberOfGuesses;
        }
        public List<char> getCurrentHangman()
        {
            return _currentHangman;
        }

        //Group5- CreateHangman. we think that it should be private and be called from the constructor
        public void CreateCurrentHangman()   // store correct number of underscores in an array
        {
            for (int i = 0; i < _secretWord.Length; i++)
            {
                _currentHangman.Add('_');
            }
        }
        public GuessResult Guess(string guess)
        {
            // OO: Nice method :)
            // OO: If the guess is Invalid you don't have to punish the user
            _numberOfGuesses--;
            if (!IsValid(guess))
            {
                return GuessResult.InvalidGuess;
            }
            parsedGuess = char.Parse(guess);
            if (_guessedLetters.Contains(parsedGuess))
                return GuessResult.AlreadyGuessed;

            if (_secretWord.Contains(parsedGuess))
            {                
                _guessedLetters.Add(parsedGuess);
                UpdateCurrentHangman(parsedGuess);
                return GuessResult.CorrectGuess;
            }
            _guessedLetters.Add(parsedGuess);
            _numberOfGuesses--;
            return GuessResult.IncorrectGuess;            
        }

        private void UpdateCurrentHangman(char guess)  // replace hangman underscore with correct letters
        {
            if (_secretWord.Contains(guess)) // byter understreck med rätt bokstav
            {
                for (int i = 0; i < _secretWord_Array.Length; i++)
                {
                    if (_secretWord_Array[i] == guess)
                        _currentHangman[i] = guess;
                }
            }            
        }

        private bool IsValid(string guess)
        {
            // Mste vara ett tecken och korrekt
            if (guess.Length != 1)
            {
                return false;
            }
            parsedGuess = char.Parse(guess);
            bool IsLetter = char.IsLetter(parsedGuess);

            if (!IsLetter)
            {
                return false;
            }
            return true;
        }

        public bool CheckWin()
        {
            if (!_currentHangman.Contains('_'))
                return true;
            else
                return false;
        }
        public bool CheckLoose()
        {
            if (_currentHangman.Contains('_') && _numberOfGuesses == 0)
                return true;
            else
                return false;
        }
    }
}
