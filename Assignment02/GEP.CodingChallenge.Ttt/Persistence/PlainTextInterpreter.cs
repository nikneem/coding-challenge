using System.Collections.Generic;
using System.Linq;
using GEP.CodingChallenge.Ttt.Base;
using GEP.CodingChallenge.Ttt.Domain;

namespace GEP.CodingChallenge.Ttt.Persistence
{
    public static class PlainTextInterpreter
    {
        public static List<Coordinate> OccupationsFromString(string inputStream, Game game )
        {
            IEnumerable<Player> players = new List<Player> {game.PlayerOne, game.PlayerTwo};
            var storedMoves = new List<Coordinate>();
            var lines = inputStream.Split('\n');
            if (lines.Length == Constants.MatrixSize)
            {
                var currentLineCount = 0;
                do
                {
                    var currentLine = lines[currentLineCount];
                    if (currentLine.Length == Constants.MatrixSize)
                    {
                        for (int character = 0; character < currentLine.Length; character++)
                        {
                            var currentCharacter = currentLine[character];
                            var player = players.FirstOrDefault(plyr => plyr.Symbol.Equals(currentCharacter));
                            if (player != null)
                            {
                                storedMoves.Add(new Coordinate(character + 1, currentLineCount + 1, player));
                            }
                        }
                    }
                    else
                    {
                        return new List<Coordinate>();
                    }

                    currentLineCount++;
                } while (currentLineCount < Constants.MatrixSize);
            }

            return storedMoves;
        }
    }

}

