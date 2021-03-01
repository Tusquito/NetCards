using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCards.Api.Core.Entities;
using NetCards.Api.Core.Enums;
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
        public async Task<ActionResult<BasicResponse>> CreateNewDeckAsync(int deckCount, bool jokerEnabled = false)
        {
            DeckInformation deckInformation = new DeckInformation
            {
                Id = _deckService.GenerateNewDeckId(),
                LastUpdate = DateTime.UtcNow,
                Cards = _deckService.GenerateDeckCards(deckCount, jokerEnabled)
            };
            
            _deckManager.AddOrUpdate(deckInformation);

            return Ok(new BasicResponse(new DefaultResponse(deckInformation)));
        }

        [HttpGet("{deckId}/shuffle")]
        public async Task<ActionResult<BasicResponse>> ShuffleDeckAsync(string deckId)
        {
            if (!_deckManager.Exists(deckId))
            {
                return BadRequest(new BasicResponse(new ErrorEntity
                {
                    Status = ErrorCode.DECK_ID_NOT_FOUND,
                    Message = ErrorCode.DECK_ID_NOT_FOUND.ToString(),
                }));
            }

            var deck = _deckManager.Get(deckId);
            _deckService.ShuffleDeck(deck);
            _deckManager.AddOrUpdate(deck);

            return Ok(new BasicResponse(new DefaultResponse(deck)));
        }
        
        [HttpGet("{deckId}/draw/{cardsCount}")]
        public async Task<ActionResult<BasicResponse>> DrawCardsAsync(string deckId, int cardsCount = 1)
        {
            if (!_deckManager.Exists(deckId))
            {
                return BadRequest(new BasicResponse(new ErrorEntity
                {
                    Status = ErrorCode.DECK_ID_NOT_FOUND,
                    Message = ErrorCode.DECK_ID_NOT_FOUND.ToString(),
                }));
            }

            var deck = _deckManager.Get(deckId);
            if (cardsCount < 0 || cardsCount > deck.Cards.Count)
            {
                return BadRequest(new BasicResponse(new ErrorEntity
                {
                    Status = ErrorCode.INVALID_CARDS_COUNT,
                    Message = ErrorCode.INVALID_CARDS_COUNT.ToString(),
                    Details = "The cards count value is negative or greater than the deck cards count."
                }));
            }

            List<CardEntity> drawnCards = _deckService.DrawCards(deck, cardsCount);
            _deckManager.AddOrUpdate(deck);
            return Ok(new BasicResponse(new DrawResponse(deck, drawnCards)));
        }
    }
}