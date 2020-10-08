using System.Text;
using ING.GEP.CodingChallenge.Core.Models.Base;
using ING.GEP.CodingChallenge.Core.ValueObjects;

namespace ING.GEP.CodingChallenge.Core.Clothing.Models
{
    public  class Cloth : CatalogItem
    {
        public string Category { get; private set; }

        public Cloth(long id, string name, string description, Price price, string category)
        : base(id, name, description, price)
        {
            Category = category;
        }

        public string ToCsvString()
        {
            var product = new StringBuilder();
            product.Append(ProductId);
            product.Append(Constants.CsvSplitCharacter);
            product.Append(Name);
            product.Append(Constants.CsvSplitCharacter);
            product.Append(Description);
            product.Append(Constants.CsvSplitCharacter);
            product.Append(Price);
            product.Append(Constants.CsvSplitCharacter);
            product.Append(Category);
            return product.ToString();
        }

    }
}
