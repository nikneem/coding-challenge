using GEP.CodingChallenge.Ttt.Domain;
using GEP.CodingChallenge.Ttt.Persistence;
using NUnit.Framework;

namespace GEP.CodingChallenge.Ttt.Tests
{
    public class Tests
    {


        [Test]
        [TestCase("XXX\nO.O\nOOX")]
        [TestCase("O.O\nXXX\nOO.")]
        [TestCase("O.O\nOO.\nXXX")]
        [TestCase("XOO\nOX.\n.OX")]
        [TestCase("OOX\n.X.\nXOO")]
        [TestCase("OXX\n.X.\nOXO")]
        [TestCase("OOX\n..X\nOOX")]
        [TestCase("XOO\nX..\nXOO")]
        [TestCase("OXX\nXXO\nOXO")]
        public void WhenPlayerXIsTheWinner_ThenTheCorrectStatusMessageIsShown(string statusRepresentation)
        {
            var expectedStatusText = "Player X is the winner!";
            var game = new Game();
            game.Initialize(PlainTextInterpreter.OccupationsFromString(statusRepresentation, game));
            var actualStatusText = game.GetStatusText();
            Assert.AreEqual(expectedStatusText, actualStatusText);
        }

        [Test]
        [TestCase("OOO\nX.X\nXXO")]
        [TestCase("X.X\nOOO\nXX.")]
        [TestCase("X.X\nXX.\nOOO")]
        [TestCase("OXX\nXO.\n.XO")]
        [TestCase("XXO\n.O.\nOXX")]
        [TestCase("XOO\n.O.\nXOX")]
        [TestCase("XXO\n..O\nXXO")]
        [TestCase("OXX\nO..\nOXX")]
        public void WhenPlayerOIsTheWinner_ThenTheCorrectStatusMessageIsShown(string statusRepresentation)
        {
            var expectedStatusText = "Player O is the winner!";
            var game = new Game();
            game.Initialize(PlainTextInterpreter.OccupationsFromString(statusRepresentation, game));
            var actualStatusText = game.GetStatusText();
            Assert.AreEqual(expectedStatusText, actualStatusText);
        }

        [Test]
        [TestCase("OXX\nXXO\nOOX")]
        public void WhenTheGameEndedAsATie_ThenTheCorrectStatusMessageIsShown(string statusRepresentation)
        {
            var expectedStatusText = "This game ended up in a tie... ;(";
            var game = new Game();
            game.Initialize(PlainTextInterpreter.OccupationsFromString(statusRepresentation, game));
            var actualStatusText = game.GetStatusText();
            Assert.AreEqual(expectedStatusText, actualStatusText);
        }

        [Test]
        [TestCase("OO.\nX.X\nXXO")]
        [TestCase("X.X\nOO.\nXXO")]
        [TestCase("XOX\nXX.\n.OO")]
        [TestCase("..X\n...\n...")]
        public void WhenPlayerXHasMoreTurns_ThenItsPlayerOTurn(string statusRepresentation)
        {
            var expectedStatusText = "It's Player O's turn";
            var game = new Game();
            game.Initialize(PlainTextInterpreter.OccupationsFromString(statusRepresentation, game));
            var actualStatusText = game.GetStatusText();
            Assert.AreEqual(expectedStatusText, actualStatusText);
        }

        [Test]
        [TestCase("...\n...\n...")]
        [TestCase(".X.\n..O\n...")]
        [TestCase("...\n.OO\nXX.")]
        [TestCase("XXO\nOOX\n...")]
        [TestCase("XOX\nOOX\n.XO")]
        public void WhenNoMovesAreMadeOrMoveCountIsEqual_ThenItsPlayerOneTurn(string statusRepresentation)
        {
            var game = new Game();
            var expectedStatusText = $"It's {game.PlayerOne.Name}'s turn";
            game.Initialize(PlainTextInterpreter.OccupationsFromString(statusRepresentation, game));
            var actualStatusText = game.GetStatusText();
            Assert.AreEqual(expectedStatusText, actualStatusText);
        }

        [Test]
        [TestCase("OOX\n...")]
        [TestCase(".X.\n..\n...")]
        public void WhenTheGameStateIsIncorrect_ThenNoOccupationsAreParsed(string statusRepresentation)
        {
            var game = new Game();
            var occupations = PlainTextInterpreter.OccupationsFromString(statusRepresentation, game);
            Assert.AreEqual(0, occupations.Count);
        }

    }
}