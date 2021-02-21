using System.Collections.Generic;
using DeckOfCards.Api.Entities;
using Newtonsoft.Json;

namespace DeckOfCards.Api.Responses
{
    /// <summary>
    /// Draw card API call response
    /// </summary>
    public class DrawCardsApiResponse : DefaultApiResponse
    {
        [JsonProperty("cards")] 
        public List<CardEntity> Cards { get; set; }
    }
}