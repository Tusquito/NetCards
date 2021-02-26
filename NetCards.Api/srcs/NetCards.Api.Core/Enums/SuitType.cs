using System;

namespace NetCards.Api.Core.Enums
{
    [Flags]
    public enum SuitType
    {
        HEARTS  = 1 << 0,
        DIAMONDS = 1 << 1,
        SPADES = 1 << 2,
        CLUBS = 1 << 3,
        NONE = 0
    }
}