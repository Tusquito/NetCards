namespace NetCards.Client.Api.Extensions
{
    /// <summary>
    /// Provide all the API routes that can be reached
    /// </summary>
    public static class ApiRouteExtensions
    {
        public const string BASE_ROUTE = "https://deckofcardsapi.com/api/deck/";
        public const string DRAW_CARD_ROUTE = "{0}/draw/?count={1}";
        public const string SHUFFLE_DECK_ROUTE = "{0}/shuffle/";
        public const string NEW_DECK_ROUTE = "new/?deck_count={0}&jokers_enabled={1}";
        public const string NEW_PARTIAL_DECK_ROUTE = "new/?cards={0}";
    }
}