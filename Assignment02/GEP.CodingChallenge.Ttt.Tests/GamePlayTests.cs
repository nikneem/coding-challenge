using System.Collections.Generic;
using GEP.CodingChallenge.Ttt.Domain;
using GEP.CodingChallenge.Ttt.Exceptions;
using NUnit.Framework;

namespace GEP.CodingChallenge.Ttt.Tests
{
    public class GamePlayTests
    {

        [Test]
        public void WhenACoordinateIsAlreadyOccupied_ItThrowsCoordinateAlreadyOccupiedException()
        {
            var game = new Game();
            var occupations = new List<Coordinate>();
            occupations.Add(new Coordinate(1, 1, game.PlayerOne));
            occupations.Add(new Coordinate(1, 1, game.PlayerTwo));
            var act = new TestDelegate(() => game.Initialize(occupations));
            Assert.Throws<CoordinateAlreadyOccupiedException>(act);
        }

    }
}
