namespace DeckOfCards.Api.Extensions
{
    public static class ComparableExtensions
    {
        /// <summary>
        /// Compares two values and returns an integer (-1, 0, 1) according to compareTo possible results
        /// </summary>
        /// <param name="firstValue">First integer value</param>
        /// <param name="secondValue">Second integer value</param>
        /// <returns></returns>
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