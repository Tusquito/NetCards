using System;
using NetCards.Api.Core.Managers;
using Newtonsoft.Json;

namespace NetCards.Api.Core.Responses
{
    public class DefaultResponse : IResponse
    {
        public DefaultResponse(DeckInformation deck)
        {
            DeckId = deck.Id;
            RemainingCards = deck.RemainingCards;
            Shuffled = deck.Shuffled;
        }
        [JsonProperty("deck_id")] public string DeckId { get; init; }
        [JsonProperty("date")] public DateTime Date => DateTime.UtcNow;
        [JsonProperty("shuffled")] public bool Shuffled { get; set; }
        [JsonProperty("remaining_cards")] public int RemainingCards { get; set; }
    }
}