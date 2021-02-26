using System;
using System.Collections.Generic;
using NetCards.Api.Core.Entities;
using NetCards.Api.Core.Enums;
using NetCards.Api.Core.Services.RandomService;

namespace NetCards.Api.Core.Services.DeckService
{
    public class DeckService : IDeckService
    {
        private readonly IRandomService _randomService;

        public DeckService(IRandomService randomService)
        {
            _randomService = randomService;
        }

        public string GenerateNewDeckId(int length = 12)
        {
            char baseChar = 'a';
            string result = "";
            for (int i = 0; i < length; i++)
            {
                var temp = (char) (baseChar + _randomService.NextInt(0, 25));
                result += _randomService.NextBool() ? temp : char.ToUpper(temp);
            }
            return result;
        }

        public List<CardEntity> GenerateDeckCards(int deckCount, bool jokerEnabled)
        {
            List<CardEntity> result = new();
            Array suitTypeValues = Enum.GetValues<SuitType>();
            Array specialCardValues = Enum.GetValues<SpecialCardValue>();
            for (int i = 0; i < deckCount; i++)
            {
                for (int j = 0; j < suitTypeValues.Length - 1; j++)
                {
                    for (int h = 2; h < 10; h++)
                    {
                        result.Add(new CardEntity
                        {
                            Value = h.ToString(),
                            Suit = (SuitType)(suitTypeValues.GetValue(j) ?? SuitType.NONE)
                        });
                    }

                    for (int k = 0; k < specialCardValues.Length; k++)
                    {
                        SpecialCardValue cardValue = (SpecialCardValue) (specialCardValues.GetValue(k) ?? SpecialCardValue.NONE);
                        result.Add(new CardEntity
                        {
                            Value = cardValue.ToString(),
                            Suit = (SuitType)(suitTypeValues.GetValue(j) ?? SuitType.NONE)
                        });
                    }
                }

                if (jokerEnabled)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        result.Add(new CardEntity
                        {
                            Value = "JOKER",
                            Suit = SuitType.NONE
                        });
                    }
                }
            }

            return result;
        }
    }
}