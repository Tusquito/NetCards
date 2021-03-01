using System.Collections.Generic;
using NetCards.Api.Core.Entities;
using NetCards.Api.Core.Managers;

namespace NetCards.Api.Core.Responses
{
    public class DrawResponse : DefaultResponse
    {
        public DrawResponse(DeckInformation deck, List<CardEntity> cards) : base(deck)
        {
            Cards = cards;
        }
        public List<CardEntity> Cards { get; }
    }
}