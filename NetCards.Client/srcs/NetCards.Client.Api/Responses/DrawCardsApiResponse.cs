using System.Collections.Generic;
using DeckOfCards.Client.Api.Entities;
using Newtonsoft.Json;

namespace DeckOfCards.Client.Api.Responses
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