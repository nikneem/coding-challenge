namespace GEP.CodingChallenge.Ship.Contracts
{
    public interface IOrder
    {
        decimal Weight { get; }
        string Country { get;  }
    }
}