using System.Collections.Generic;
using NetCards.Client.Api.Entities;
using Newtonsoft.Json;

namespace NetCards.Client.Api.Responses
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