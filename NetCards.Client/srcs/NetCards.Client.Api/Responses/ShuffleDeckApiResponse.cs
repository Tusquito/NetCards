using Newtonsoft.Json;

namespace NetCards.Client.Api.Responses
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