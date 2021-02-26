namespace NetCards.Api.Core.Services.RandomService
{
    public interface IRandomService
    {
        public int NextInt(int min);
        public int NextInt(int min, int max);
        public int NextInt();
        public bool NextBool();
    }
}