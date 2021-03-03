using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using NetCards.Api.Core.Entities;

namespace NetCards.Api.Core.Managers
{
    public class DeckManager : BackgroundService, IManager<string, DeckInformation>
    {
        private readonly ConcurrentDictionary<string, DeckInformation> _decks = new();
        private readonly TimeSpan _updateDelay = TimeSpan.FromSeconds(Convert.ToInt32(Environment.GetEnvironmentVariable("DECK_MANAGER_UPDATE_DELAY") ?? "60"));
        private readonly TimeSpan _deckDuration = TimeSpan.FromMinutes(Convert.ToInt32(Environment.GetEnvironmentVariable("DECK_MANAGER_DECK_DURATION") ?? "60"));

        public bool Exists(string key)
        {
            return _decks.ContainsKey(key);
        }

        public void AddOrUpdate(DeckInformation obj)
        {
            obj.LastUpdate = DateTime.UtcNow;
            _decks[obj.Id] = obj;
        }

        public void Remove(string key)
        {
            _decks.TryRemove(key, out _);
        }

        public DeckInformation Get(string key)
        {
            _decks[key].LastUpdate = DateTime.UtcNow;
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

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var decksToDelete = _decks.Where(p => p.Value.LastUpdate + _deckDuration < DateTime.UtcNow);
                foreach (var (deckId, deck) in decksToDelete)
                {
                    Remove(deckId);
                }
                await Task.Delay(_updateDelay, stoppingToken);
            }
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