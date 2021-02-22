namespace DeckOfCards.Client.Game.Entities
{
    public class DeckConfiguration
    {
        public string DeckId { get; set; }
        public int RemainingCards { get; set; }
        public int DeckCount { get; set; }
        public bool JokersEnabled { get; set; }
    }
}