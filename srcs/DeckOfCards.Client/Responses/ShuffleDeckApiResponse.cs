using Newtonsoft.Json;

namespace DeckOfCards.Client.Responses
{
    public class ShuffleDeckApiResponse : DefaultApiResponse
    {
        [JsonProperty("shuffled")] 
        public bool Shuffled { get; set; }
    }
}