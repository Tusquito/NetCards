using System.Collections.Generic;
using NetCards.Client.Api.Entities;

namespace NetCards.Client.Game.Entities
{
    public class PlayerEntity
    {
        public List<CardEntity> Cards { get; } = new();
    }
}