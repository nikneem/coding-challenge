using ING.GEP.CodingChallenge.Core.Enums;

namespace ING.GEP.CodingChallenge.Core.ValueObjects
{
    public class Price
    {
        public decimal Amount { get; private set; }
        public Currency Currency { get; private set; }

        public void ConvertTo(Currency currency)
        {
            Amount = currency.ConvertAmountFrom(Amount, Currency);
            Currency = currency;
        }

        public Price(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override string ToString()
        {
            return $"{Amount:F}";
        }
    }
}