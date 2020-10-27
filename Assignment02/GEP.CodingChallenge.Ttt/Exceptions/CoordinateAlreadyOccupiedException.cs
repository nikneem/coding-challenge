using System;

namespace GEP.CodingChallenge.Ttt.Exceptions
{
    public class CoordinateAlreadyOccupiedException : Exception
    {
        public CoordinateAlreadyOccupiedException(string message, Exception innerEx = null) : base(message, innerEx)
        {
        }
    }
}