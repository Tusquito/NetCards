using System.Collections.Generic;
using NetCards.Api.Core.Entities;
using NetCards.Api.Core.Managers;

namespace NetCards.Api.Core.Services.DeckService
{
    public interface IDeckService
    {
        public string GenerateNewDeckId(int length = 12);
        public List<CardEntity> GenerateDeckCards(int deckCount, bool jokerEnabled);
        public void ShuffleDeck(DeckInformation deck);
        public List<CardEntity> DrawCards(DeckInformation deck, int count);
    }
}