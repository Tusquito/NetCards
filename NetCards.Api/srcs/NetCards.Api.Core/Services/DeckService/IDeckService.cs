using System.Collections.Generic;
using NetCards.Api.Core.Entities;

namespace NetCards.Api.Core.Services.DeckService
{
    public interface IDeckService
    {
        public string GenerateNewDeckId(int length = 12);
        public List<CardEntity> GenerateDeckCards(int deckCount, bool jokerEnabled);
    }
}