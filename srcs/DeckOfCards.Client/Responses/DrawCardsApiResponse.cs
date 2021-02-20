using System.Collections.Generic;
using DeckOfCards.Client.Entities;
using Newtonsoft.Json;

namespace DeckOfCards.Client.Responses
{
    public class DrawCardsApiResponse : DefaultApiResponse
    {
        [JsonProperty("cards")] 
        public List<CardEntity> Cards { get; set; }
    }
}