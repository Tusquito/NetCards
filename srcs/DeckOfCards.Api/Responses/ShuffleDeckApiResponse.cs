using Newtonsoft.Json;

namespace DeckOfCards.Api.Responses
{
    /// <summary>
    /// Deck shuffle API call response
    /// </summary>
    public class ShuffleDeckApiResponse : DefaultApiResponse
    {
        [JsonProperty("shuffled")] 
        public bool Shuffled { get; set; }
    }
}