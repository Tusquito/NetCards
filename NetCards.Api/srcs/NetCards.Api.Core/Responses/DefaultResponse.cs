using System;
using Newtonsoft.Json;

namespace NetCards.Api.Core.Responses
{
    public class DefaultResponse
    {
        [JsonProperty("deck_id")]
        public string DeckId { get; init; }
        
        [JsonProperty("date")]
        public DateTime Date { get; init; }
        
        [JsonProperty("success")] 
        public bool Success { get; init; }
        
        [JsonProperty("remaining_cards")]
        public int RemainingCards { get; set; }
    }
}