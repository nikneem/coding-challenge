using System;
using ING.GEP.CodingChallenge.Core.Enums;
using ING.GEP.CodingChallenge.Core.Exceptions;
using ING.GEP.CodingChallenge.Core.ValueObjects;

namespace ING.GEP.CodingChallenge.Core.Clothing.Models
{
    public class ClothsFactory
    {
        public static Cloth FromCsvString(string csvLine, bool trimFields = Constants.TrimImportedFields)
        {
            try
            {
                var fields = string.IsNullOrWhiteSpace(csvLine) 
                    ? null
                    : csvLine.Split(Constants.CsvSplitCharacter);
                if (fields?.Length != 5)
                {
                    throw new Exception("Failed to import CSV line as Cloth, could not find the expected amount of 5 fields");
                }

                var name = trimFields ? fields[1].Trim() : fields[1];
                var description = trimFields ? fields[2].Trim() : fields[2];
                var category = trimFields ? fields[4].Trim() : fields[4];

                if (!long.TryParse(fields[0], out long id))
                {
                    throw new Exception("Product ID could not be converted to a long");
                }

                if (!decimal.TryParse(fields[3], out var priceInDollars))
                {
                    throw new Exception("The import price could not be parsed to a valid decimal");
                }

                var price = new Price(priceInDollars, Currency.Dollar);
                return new Cloth(id, name, description, price, category);
            }
            catch (Exception ex)
            {
                throw new LineImportException("Failed to import CSV line as Cloth object", ex);
            }
        }
    }
}