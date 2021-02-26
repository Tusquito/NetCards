using System;

namespace NetCards.Api.Core.Enums
{
    [Flags]
    public enum SpecialCardValue
    {
        JACK = 1 << 0,
        QUEEN = 1 << 1,
        KING = 1 << 2,
        ACE = 1 << 3, 
        NONE = 0
    }
}