using System;

namespace ING.GEP.CodingChallenge.Core.Exceptions
{
    public class LineImportException : Exception
    {

        public LineImportException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}
