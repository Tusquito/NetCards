using System;
using DeckOfCards.Client.Api.Enums;
using DeckOfCards.Client.Game.Entities;

namespace DeckOfCards.Client.Game.Extensions
{
    public static class PlayerExtensions
    {
        public static int GetPlayerCardsSum(this PlayerEntity player, bool isBlackJack)
        {
            int sum = 0;
            foreach (var card in player.Cards)
            {
                if (int.TryParse(card.Value, out var value))
                {
                    sum += value;
                    continue;
                }

                if (Enum.Parse<SpecialCardValue>(card.Value) != SpecialCardValue.ACE)
                {
                    sum += 10;
                    continue;
                }
 
                if (isBlackJack && sum + 11 <= 21)
                {
                    sum += 11;
                    continue;
                }

                sum += 1;

            }

            return sum;
        }
    }
}