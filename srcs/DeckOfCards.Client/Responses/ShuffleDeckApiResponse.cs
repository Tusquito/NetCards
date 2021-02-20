using Newtonsoft.Json;

namespace DeckOfCards.Client.Responses
{
    public class ShuffleDeckApiApiResponse : DefaultApiResponse
    {
        [JsonProperty("shuffled")] 
        public bool Shuffled { get; set; }
    }
}