using System.Collections.Generic;
using System.Threading.Tasks;
using NetCards.Client.Api;
using NetCards.Client.Game.Entities;
using NetCards.Client.Game.Extensions;

namespace NetCards.Client.Game
{
    public class GameClient
    {
        private readonly DeckConfiguration _deckConfiguration = new();
        private readonly ApiClient _apiClient = new();
        private readonly List<PlayerEntity> _players = new();
        public GameClient(int playerCount, int deckCount, bool jokersEnabled)
        {
            for(int i = 0; i < playerCount; i++)
            {
                _players.Add(new PlayerEntity());
            }

            _deckConfiguration.JokersEnabled = jokersEnabled;
            _deckConfiguration.DeckCount = deckCount;
        }

        private async Task CheckDeckValidityAsync()
        {
            if (_deckConfiguration.DeckId == null || _deckConfiguration.RemainingCards == 0)
            {
                var response = await _apiClient.CreateNewDeckAsync(_deckConfiguration.DeckCount, _deckConfiguration.JokersEnabled);
                await _apiClient.ShuffleDeckAsync(response.DeckId);
                _deckConfiguration.DeckId = response.DeckId;
                _deckConfiguration.RemainingCards = response.RemainingCards;
            }
        }
        public async Task DrawCardToPlayerAsync(int playerIndex, int cardCount)
        {
            await CheckDeckValidityAsync();
            var response = await _apiClient.DrawCardsAsync(_deckConfiguration.DeckId, cardCount);
            
            _players[playerIndex].Cards.AddRange(response.Cards);
            
            if (response.Cards.Count < cardCount)
            {
                await DrawCardToPlayerAsync(playerIndex, response.Cards.Count - cardCount);
            }
        }

        public void ClearPlayerPile(int playerIndex)
        {
            _players[playerIndex].Cards.Clear();
        }

        public int GetPlayerPileSum(int playerIndex, bool isBlackJack = false)
        {
            return _players[playerIndex].GetPlayerCardsSum(isBlackJack);
        }
    }
}