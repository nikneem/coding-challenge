using GEP.CodingChallenge.Ttt.Base;

namespace GEP.CodingChallenge.Ttt.Domain
{
    public class PlayerTwo : Player
    {
        public override char Symbol => 'O';

        public PlayerTwo(string name = null)
        {
            Name = name ?? $"Player {Symbol}";
        }

    }
}
