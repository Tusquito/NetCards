using System;

namespace NetCards.Api.Core.Services.RandomService
{
    public class RandomService : IRandomService
    {
        private static readonly Random Random = new(Guid.NewGuid().GetHashCode());
        
        public int NextInt(int min)
        {
           return Random.Next(min);
        }

        public int NextInt(int min, int max)
        {
            return Random.Next(min, max);
        }

        public int NextInt()
        {
            return Random.Next();
        }

        public bool NextBool()
        {
            return Random.Next(0, 2) > 0;
        }
    }
}