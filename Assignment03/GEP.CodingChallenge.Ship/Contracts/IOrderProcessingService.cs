using System.Collections.Generic;
using GEP.CodingChallenge.Ship.Models;

namespace GEP.CodingChallenge.Ship.Contracts
{
    public interface IOrderProcessingService
    {
        IEnumerable<Shipment> Process(List<string> importLines);
    }
}