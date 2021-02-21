using System.Collections.Generic;
using DeckOfCards.Api.Entities;

namespace DeckOfCards.Game.Entities
{
    public class PlayerEntity
    {
        public List<CardEntity> Cards { get; } = new();
    }
}