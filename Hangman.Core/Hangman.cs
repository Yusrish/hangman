using System.Collections.Generic;
using System.Dynamic;

namespace Hangman
{
    public class Hangman
    {
        //Group5 - Do you really need both _secretWord and _secretWord_Array? can you combine these?
        private string _secretWord;
        private char[] _secretWord_Array;
        private int _numberOfGuesses;
        private List<char> _guessedLetters = new List<char>();
        private List<char> _currentHangman = new List<char>();
        private char parsedGuess;

        public Hangman(string secretWord, int nrOfGuesses)
        {
            _secretWord = secretWord;
            _secretWord_Array = _secretWord.ToCharArray();
            _numberOfGuesses = nrOfGuesses;
            CreateCurrentHangman();
        }

        //public string SecretWord { get; set; }
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

        // OO: Namngivning
        //Group5- CreateHangman. we think that it should be private and be called from the constructor
        private void CreateCurrentHangman()   
        {
            for (int i = 0; i < _secretWord.Length; i++)
            {
                _currentHangman.Add('_');
            }
        }

        public GuessResult Guess(string guess)
        {   
            if (!IsValid(guess))
            {
                return GuessResult.InvalidGuess;
            }
            parsedGuess = char.Parse(guess);
            if (_guessedLetters.Contains(parsedGuess))
                return GuessResult.AlreadyGuessed;

            if (_secretWord.Contains(parsedGuess.ToString()))
            {                
                _guessedLetters.Add(parsedGuess);
                UpdateCurrentHangman(parsedGuess);
                return GuessResult.CorrectGuess;
            }
            _guessedLetters.Add(parsedGuess);
            _numberOfGuesses--;
            return GuessResult.IncorrectGuess;            
        }

        private void UpdateCurrentHangman(char parsedGuess)  
        {
            if (_secretWord.Contains(parsedGuess.ToString())) 
            {
                for (int i = 0; i < _secretWord_Array.Length; i++)
                {
                    if (_secretWord_Array[i] == parsedGuess)
                        _currentHangman[i] = parsedGuess;
                }
            }            
        }

        private bool IsValid(string guess)
        {
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


        // OO: e.g "HasWon"
        public bool HasWon()
        {
            if (!_currentHangman.Contains('_'))
                return true;
            else
                return false;
        }

        public bool HasLost()
        {
            if (_currentHangman.Contains('_') && _numberOfGuesses == 0)
                return true;
            else
                return false;
        }
    }
}
