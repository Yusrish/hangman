using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman.Core.Test
{
    [TestClass]
    public class Hangman_Guess
    {
        [TestMethod]
        public void should_return_CorrectGuess_when_guessing_A()
        {
            // Arrange
            var hangman = new Hangman("KALLE", 3);
            // Act
            GuessResult result = hangman.Guess("A");
            // Assert
            Assert.AreEqual(GuessResult.CorrectGuess, result);
        }

        [TestMethod]
        public void should_return_AlreadyGuessed_when_guessing_A_twice()
        {
            // Arrange
            var hangman = new Hangman("KALLE", 3);
            // Act
            GuessResult result = hangman.Guess("A");
            result = hangman.Guess("A");
            // Assert
            Assert.AreEqual(GuessResult.AlreadyGuessed, result);
        }

        [TestMethod]
        public void should_return_InvalidGuess_when_guessing_a_number_or_any_sign()
        {
            // Arrange
            var hangman = new Hangman("KALLE", 3);
            // Act
            GuessResult result = hangman.Guess("4");
            // Assert
            Assert.AreEqual(GuessResult.InvalidGuess, result);
        }

        [TestMethod]
        public void should_return_InvalidGuess_when_guessing_a_multiple_letters_or_any_string()
        {
            // Arrange
            var hangman = new Hangman("KALLE", 3);
            // Act
            GuessResult result = hangman.Guess("abcd");
            // Assert
            Assert.AreEqual(GuessResult.InvalidGuess, result);
        }

        [TestMethod]
        public void the_user_wins_if_hidden_word_guessed()
        {
            // Arrange
            var hangman = new Hangman("KALLE", 3);
            GuessResult result = hangman.Guess("K");
            result = hangman.Guess("A");
            result = hangman.Guess("L");
            result = hangman.Guess("E");
            bool win = hangman.HasWon();
            // Assert
            Assert.AreEqual(true, win);
        }

        [TestMethod]
        public void the_user_loses_if_hidden_word_not_guessed()
        {
            // Arrange
            var hangman = new Hangman("KALLE", 3);
            GuessResult result = hangman.Guess("F");
            result = hangman.Guess("A");
            result = hangman.Guess("L");
            result = hangman.Guess("E");
            bool win = hangman.HasWon();
            // Assert
            Assert.AreEqual(false, win);
        }

        [TestMethod]
        public void the_user_should_lose_if_number_of_guesses_are_more_than_limit()
        {
            // Arrange
            var hangman = new Hangman("KALLE", 3);
            GuessResult result = hangman.Guess("G");
            result = hangman.Guess("F");
            result = hangman.Guess("P");
            bool win = hangman.HasLost();
            // Assert
            Assert.AreEqual(true, win);
        }
        // OO: test för vinst och förslut
    }
}
