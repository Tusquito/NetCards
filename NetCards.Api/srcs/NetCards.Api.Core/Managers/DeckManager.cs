using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using NetCards.Api.Core.Entities;

namespace NetCards.Api.Core.Managers
{
    public class DeckManager : IManager<string, DeckInformation>
    {
        private readonly ConcurrentDictionary<string, DeckInformation> _decks = new();

        public bool Exists(string key)
        {
            return _decks.ContainsKey(key);
        }

        public void AddOrUpdate(DeckInformation obj)
        {
            _decks[obj.Id] = obj;
        }

        public void Remove(string key)
        {
            _decks.TryRemove(key, out _);
        }

        public DeckInformation Get(string key)
        {
            return _decks[key];
        }

        public IEnumerable<DeckInformation> GetAll()
        {
            return _decks.Values;
        }

        public void RemoveAll()
        {
            _decks.Clear();
        }
    }

    public class DeckInformation
    {
        public string Id { get; init; }
        public DateTime LastUpdate { get; set; }
        public List<CardEntity> Cards { get; init; }
        public bool Shuffled { get; set; }
        public int RemainingCards => Cards.Count;
    }
}