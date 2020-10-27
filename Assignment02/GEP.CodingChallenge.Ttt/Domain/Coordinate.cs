using GEP.CodingChallenge.Ttt.Base;
using GEP.CodingChallenge.Ttt.Exceptions;

namespace GEP.CodingChallenge.Ttt.Domain
{
    public class Coordinate
    {
        public int CoordX { get; }
        public int CoordY { get; }
        public Player Occupation { get; private set; }

        internal void Occupy(Player value)
        {
            if (Occupation != null)
            {
                throw new CoordinateAlreadyOccupiedException($"Coordinate '{CoordX}', '{CoordY}' is already occupied by player '{Occupation.Name}'");
            }

            Occupation = value;
        }
        public Coordinate(int x, int y, Player player = null)
        {
            CoordX = x;
            CoordY = y;
            Occupation = player;
        }

    }
}