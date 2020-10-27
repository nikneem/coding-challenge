using System.Collections.Generic;
using System.Linq;
using GEP.CodingChallenge.Ttt.Base;

namespace GEP.CodingChallenge.Ttt.Domain
{
    public class Matrix
    {

        private List<Coordinate> _playfield;


        internal bool HasWinner => GetWinner() != null;
        internal int CountPlayerMoves(Player player)
        {
            return _playfield.Count(coord => coord.Occupation == player);
        }
        internal int CountTotalMoves()
        {
            return _playfield.Count(coord => coord.Occupation != null);
        }
        internal Player GetWinner()
        {
            Player gameWinner = null;
            for (int coordinate = 1; coordinate <= Constants.MatrixSize; coordinate++)
            {
                var winnerForXCoords = GetWinnerForXCoordinates(coordinate);
                var winnerForYCoords = GetWinnerForYCoordinates(coordinate);
                gameWinner ??= winnerForXCoords ?? winnerForYCoords;
            }

            return gameWinner ?? GetWinnerForDiagonalOne() ?? GetWinnerForDiagonalTwo();
        }

        internal void Occupy(int x, int y, Player player)
        {
            var coordinate = _playfield.FirstOrDefault(coord => coord.CoordX == x && coord.CoordY == y);
            coordinate.Occupy(player);
        }

        private IEnumerable<Coordinate> ConstructGameMatrix()
        {
            for (int x = 1; x <= Constants.MatrixSize; x++)
            {
                for (int y = 1; y <= Constants.MatrixSize; y++)
                {
                    yield return new Coordinate(x, y);
                }
            }
        }


        private Player GetWinnerForXCoordinates(int coordinate)
        {
            Player winner = null;
            var columnOccupations = _playfield.Where(pf => pf.CoordX == coordinate && pf.Occupation != null)
                .GroupBy(
                    p => p.Occupation,
                    p => p.Occupation,
                    (baseOcc, occs) => new
                    {
                        Player = baseOcc,
                        Count = occs.Count()
                    });

            var winningOccupations = columnOccupations.FirstOrDefault(x => x.Count == Constants.MatrixSize);
            if (winningOccupations != null)
            {
                winner= winningOccupations.Player;
            }

            return winner;
        }
        private Player GetWinnerForYCoordinates(int coordinate)
        {
            Player winner = null;
            var columnOccupations = _playfield.Where(pf => pf.CoordY == coordinate && pf.Occupation != null)
                .GroupBy(
                    p => p.Occupation,
                    p => p.Occupation,
                    (baseOcc, occs) => new
                    {
                        Player = baseOcc,
                        Count = occs.Count()
                    });

            var winningOccupations = columnOccupations.FirstOrDefault(x => x.Count == Constants.MatrixSize);
            if (winningOccupations != null)
            {
                winner = winningOccupations.Player;
            }

            return winner;
        }

        private Player GetWinnerForDiagonalOne()
        {
            Player winner = null;
            var columnOccupations = _playfield.Where(pf => pf.CoordX == pf.CoordY && pf.Occupation != null)
                .GroupBy(
                    p => p.Occupation,
                    p => p.Occupation,
                    (baseOcc, occs) => new
                    {
                        Player = baseOcc,
                        Count = occs.Count()
                    });

            var winningOccupations = columnOccupations.FirstOrDefault(x => x.Count == Constants.MatrixSize);
            if (winningOccupations != null)
            {
                winner = winningOccupations.Player;
            }

            return winner;
        }
        private Player GetWinnerForDiagonalTwo()
        {
            Player winner = null;
            var columnOccupations = _playfield.Where(pf => pf.CoordX == (Constants.MatrixSize +1)- pf.CoordY && pf.Occupation != null)
                .GroupBy(
                    p => p.Occupation,
                    p => p.Occupation,
                    (baseOcc, occs) => new
                    {
                        Player = baseOcc,
                        Count = occs.Count()
                    });

            var winningOccupations = columnOccupations.FirstOrDefault(x => x.Count == Constants.MatrixSize);
            if (winningOccupations != null)
            {
                winner = winningOccupations.Player;
            }

            return winner;
        }

        public Matrix()
        {
            _playfield = ConstructGameMatrix().ToList();
        }

    }
}