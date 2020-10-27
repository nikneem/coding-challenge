using System;

namespace GEP.CodingChallenge.Ttt.Base
{
    public abstract class Player
    {
        public string Name { get; protected set; }
        public abstract Char Symbol { get; }
    }
}
