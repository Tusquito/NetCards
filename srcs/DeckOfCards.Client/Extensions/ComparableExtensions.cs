namespace DeckOfCards.Client.Extensions
{
    public static class ComparableExtensions
    {
        public static int IntegerComparisonResult(int firstValue, int secondValue)
        {
            if (firstValue < secondValue)
            {
                return -1;
            }

            if (firstValue == secondValue)
            {
                return 0;
            }

            if (firstValue > secondValue)
            {
                return 1;
            }

            return -1;
        }
    }
}