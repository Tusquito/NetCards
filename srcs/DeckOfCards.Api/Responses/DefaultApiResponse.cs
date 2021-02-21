using System.Net;
using Newtonsoft.Json;

namespace DeckOfCards.Api.Responses
{
    /// <summary>
    /// Base response of any API call
    /// </summary>
    public class DefaultApiResponse : IApiResponse
    {
        [JsonProperty("success")] 
        public bool Success { get; set; }
        [JsonProperty("deck_id")]
        public string DeckId { get; set; }
        [JsonProperty("remaining")] 
        public int RemainingCards { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}