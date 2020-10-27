using System;
using System.Collections.Generic;
using System.Text;
using GEP.CodingChallenge.Ttt.Base;

namespace GEP.CodingChallenge.Ttt.Domain
{
    public class PlayerOne : Player
    {
        public override char Symbol => 'X';

        public PlayerOne(string name = null)
        {
            Name = name ?? $"Player {Symbol}";
        }
    }
}
