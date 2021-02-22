using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCards.Client.Api;
using NetCards.Client.Api.Entities;
using NetCards.Client.Game.Entities;
using NetCards.Client.Game.Extensions;

namespace NetCards.Client.Game
{
    public class GameClient
    {
        private readonly DeckConfiguration _deckConfiguration = new();
        private readonly NetCardsClient _netCardsClient = new();
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
                var response = await _netCardsClient.CreateNewDeckAsync(_deckConfiguration.DeckCount, _deckConfiguration.JokersEnabled);
                await _netCardsClient.ShuffleDeckAsync(response.DeckId);
                _deckConfiguration.DeckId = response.DeckId;
                _deckConfiguration.RemainingCards = response.RemainingCards;
            }
        }

        private bool IsPlayerIndexValid(int playerIndex)
        {
            return playerIndex < 0 || playerIndex > _players.Count;
        }
        public async Task DrawCardToPlayerAsync(int playerIndex, int cardCount)
        {
            if (IsPlayerIndexValid(playerIndex))
            {
                throw new ArgumentOutOfRangeException();
            }
            await CheckDeckValidityAsync();
            var response = await _netCardsClient.DrawCardsAsync(_deckConfiguration.DeckId, cardCount);
            
            _players[playerIndex].Cards.AddRange(response.Cards);
            
            if (response.Cards.Count < cardCount)
            {
                await DrawCardToPlayerAsync(playerIndex, response.Cards.Count - cardCount);
            }
        }

        public void ClearPlayerPile(int playerIndex)
        {
            if (IsPlayerIndexValid(playerIndex))
            {
                throw new ArgumentOutOfRangeException();
            }
            _players[playerIndex].Cards.Clear();
        }
        
        public int GetPlayerPileSum(int playerIndex, bool isBlackJack = false)
        {
            if (IsPlayerIndexValid(playerIndex))
            {
                throw new ArgumentOutOfRangeException();
            }
            return _players[playerIndex].GetPlayerCardsSum(isBlackJack);
        }

        public List<CardEntity> GetPlayerCards(int playerIndex)
        {
            if (IsPlayerIndexValid(playerIndex))
            {
                throw new ArgumentOutOfRangeException();
            }
            return _players[playerIndex].Cards;
        }
    }
}