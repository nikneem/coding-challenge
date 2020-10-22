using System.Collections.Generic;
using GEP.CodingChallenge.Ttt.Base;

namespace GEP.CodingChallenge.Ttt.Domain
{
    public sealed class Game
    {
        private Matrix _gameMatrix;

        public PlayerOne PlayerOne { get; private set; }
        public PlayerTwo PlayerTwo { get; private set; }

        public bool HasWinner => _gameMatrix.HasWinner;
        public bool HasEnded => _gameMatrix.CountTotalMoves() == Constants.MatrixSize * Constants.MatrixSize;

        public Player GetWinner()
        {
            return _gameMatrix.GetWinner();
        }

        public Player GetPlayerWhoHasTurn()
        {
            var playerOneMoves = _gameMatrix.CountPlayerMoves(PlayerOne);
            var playerTwoMoves = _gameMatrix.CountPlayerMoves(PlayerTwo);
            return playerOneMoves > playerTwoMoves ? (Player)PlayerTwo: PlayerOne;
        }

        public string GetStatusText()
        {
            var player = GetWinner() ?? GetPlayerWhoHasTurn();
            if (HasEnded && !HasWinner)
            {
                return "This game ended up in a tie... ;(";
            }
            var statusText = HasWinner ? $"{player.Name} is the winner!" : $"It's {player.Name}'s turn";
            return statusText;
        }


        public void Initialize(IEnumerable<Coordinate> occupations)
        {
            foreach (var occ in occupations)
            {
                _gameMatrix.Occupy(occ.CoordX, occ.CoordY, occ.Occupation);
            }
        }

        public Game(string playerOneName = null, string playerTwoName = null)
        {
            PlayerOne = new PlayerOne(playerOneName);
            PlayerTwo = new PlayerTwo(playerTwoName);
            _gameMatrix = new Matrix();
        }
    }
}
