namespace ING.GEP.CodingChallenge.Core.Enums
{
    public abstract class Currency
    {

        public static Currency Dollar;
        public static Currency Euro;
        public static Currency[] All;


        public abstract decimal ExchangeRate { get; }

        public decimal ConvertAmountFrom(decimal amount, Currency currency)
        {
            var amountInDollars = amount / currency.ExchangeRate;
            return decimal.Round(amountInDollars * ExchangeRate, 2);
        }

        static Currency()
        {
            All = new[]
            {
                Dollar = new DollarCurrency(),
                Euro = new EuroCurrency()
            };
        }

        private class DollarCurrency : Currency
        {
            public override decimal ExchangeRate => 1.0M;
        }

        private class EuroCurrency : Currency
        {
            public override decimal ExchangeRate => 0.85M;
        }

    }
}