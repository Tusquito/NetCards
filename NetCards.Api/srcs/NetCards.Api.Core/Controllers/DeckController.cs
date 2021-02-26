using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCards.Api.Core.Managers;
using NetCards.Api.Core.Responses;
using NetCards.Api.Core.Services.DeckService;

namespace NetCards.Api.Core.Controllers
{
    [ApiController]
    [Route("deck/")]
    public class DeckController : ControllerBase
    {
        private readonly IManager<string, DeckInformation> _deckManager;
        private readonly IDeckService _deckService;

        public DeckController(IManager<string, DeckInformation> deckManager, IDeckService deckService)
        {
            _deckManager = deckManager;
            _deckService = deckService;
        }

        [HttpPost("new/")]
        public async Task<ActionResult<DefaultResponse>> CreateNewDeck(int deckCount, bool jokerEnabled = false)
        {
            DeckInformation deckInformation = new DeckInformation
            {
                Id = _deckService.GenerateNewDeckId(),
                LastUpdate = DateTime.UtcNow,
                Cards = _deckService.GenerateDeckCards(deckCount, jokerEnabled)
            };
            _deckManager.AddOrUpdate(deckInformation);

            return Ok(new DefaultResponse
            {
                DeckId = deckInformation.Id,
                RemainingCards = deckInformation.RemainingCards,
                Success = true,
                Date = DateTime.UtcNow
            });
        }
    }
}