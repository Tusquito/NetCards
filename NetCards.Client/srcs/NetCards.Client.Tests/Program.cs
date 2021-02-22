using System.Threading.Tasks;
using NetCards.Client.Game;

namespace NetCards.Client.Tests
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            GameClient gameClient = new GameClient(3, 3, false);
            await gameClient.DrawCardToPlayerAsync(1, 10);
            var test = gameClient.GetPlayerPileSum(1);

        }
    }
}