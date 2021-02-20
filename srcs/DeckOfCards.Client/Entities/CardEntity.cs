using DeckOfCards.Client.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DeckOfCards.Client.Entities
{
    public class CardEntity
    {
        [JsonProperty("image")] 
        public string ImageUrl { get; set; }
        [JsonProperty("value")] 
        public string Value { get; set; }
        [JsonProperty("suit"), JsonConverter(typeof(StringEnumConverter))] 
        public SuitType Suit { get; set; }
        [JsonProperty("code")] 
        public string Code { get; set; }
    }
}