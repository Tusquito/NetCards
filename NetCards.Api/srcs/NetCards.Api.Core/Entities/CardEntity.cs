using System;
using NetCards.Api.Core.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NetCards.Api.Core.Entities
{
    public class CardEntity
    {
        [JsonProperty("value")] public string Value { get; init; }
        [JsonProperty("suit")] 
        [JsonConverter(typeof(StringEnumConverter))]
        public SuitType Suit { get; init; }

        [JsonProperty("code")]
        public string Code =>
            $"{(int.TryParse(Value, out var result) ? (result < 10 ? result : 0) : Value.Substring(0,1))}{Suit.ToString()[0]}";

        [JsonProperty("image_url")]
        public string ImageUrl =>
            $"{Environment.GetEnvironmentVariable("ASPNETCORE_URLS")}/images/{Suit.ToString().ToLower()}/{Code}";
    }
}