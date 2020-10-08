using ING.GEP.CodingChallenge.Core.ValueObjects;
using Newtonsoft.Json;

namespace ING.GEP.CodingChallenge.Core.Models.Base
{
    public abstract class CatalogItem
    {

        [JsonProperty("productId")] public long ProductId { get; set; }
        [JsonProperty("name")] public string Name{ get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("price")] public Price Price { get; set; }


        protected CatalogItem(long id, string name, string description, Price price)
        {
            ProductId = id;
            Name = name;
            Description = description;
            Price = price;
        }

    }
}