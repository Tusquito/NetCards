using System.Collections.Generic;
using DeckOfCards.Client.Api.Entities;

namespace DeckOfCards.Client.Game.Entities
{
    public class PlayerEntity
    {
        public List<CardEntity> Cards { get; } = new();
    }
}