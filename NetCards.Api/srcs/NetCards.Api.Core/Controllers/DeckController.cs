using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCards.Api.Core.Responses;

namespace NetCards.Api.Core.Controllers
{
    [ApiController]
    [Route("deck/")]
    public class DeckController : ControllerBase
    {
        [HttpPost("new/")]
        public async Task<ActionResult<DefaultResponse>> CreateNewDeck(int deckCount, bool jokerEnabled = false)
        {
            return null;
        }
    }
}