using System;
using DeckOfCards.Client.Enums;
using DeckOfCards.Client.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DeckOfCards.Client.Entities
{
    public class CardEntity : IComparable
    {
        [JsonProperty("image")] 
        public string ImageUrl { get; set; }
        [JsonProperty("value")] 
        public string Value { get; set; }
        [JsonProperty("suit"), JsonConverter(typeof(StringEnumConverter))] 
        public SuitType Suit { get; set; }
        [JsonProperty("code")] 
        public string Code { get; set; }


        public int CompareTo(object obj)
        {
            if (obj is not CardEntity entity)
            {
                throw new InvalidCastException($"Can't cast {obj.GetType()} to {typeof(CardEntity)}");
            }

            int firstValue, secondValue;
            
            if (int.TryParse(Value, out firstValue) && int.TryParse(entity.Value, out secondValue))
            {
                return ComparableExtensions.IntegerComparisonResult(firstValue, secondValue);
            }

            if (int.TryParse(Value, out firstValue) && !int.TryParse(entity.Value, out secondValue))
            {
                return -1;
            }

            if (!int.TryParse(Value, out firstValue) && int.TryParse(entity.Value, out secondValue))
            {
                return 1;
            }

            return ComparableExtensions.IntegerComparisonResult((int) Enum.Parse<SpecialCardValues>(Value), (int) Enum.Parse<SpecialCardValues>(entity.Value));
        }
    }
}