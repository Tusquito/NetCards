using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DeckOfCards.Client.Api.Builders;
using DeckOfCards.Client.Api.Extensions;
using DeckOfCards.Client.Api.Responses;
using Newtonsoft.Json;

namespace DeckOfCards.Client.Api
{    /// <summary>
     /// Main class that allows to proceed all API calls
     /// </summary>
    public class ApiClient
    {
        private static readonly HttpClient HttpClient = new();

        public ApiClient()
        {
            HttpClient.BaseAddress = new Uri(ApiRouteExtensions.BASE_ROUTE);
        }
        /// <summary>
        /// Create a new deck from the API 
        /// </summary>
        /// <param name="deckCount">The count of deck (52 cards) this deck has to contain</param>
        /// <param name="jokersEnabled">If the jokers are enabled or not</param>
        /// <returns></returns>
        public async Task<ShuffleDeckApiResponse> CreateNewDeckAsync(int deckCount = 1, bool jokersEnabled = true)
        {
            var response = await HttpClient.GetAsync(string.Format(ApiRouteExtensions.NEW_DECK_ROUTE, deckCount, jokersEnabled.ToString().ToLower()));
            try
            {
                response.EnsureSuccessStatusCode();
                return new ApiResponseBuilder<ShuffleDeckApiResponse>(
                        JsonConvert.DeserializeObject<ShuffleDeckApiResponse>(
                            await response.Content.ReadAsStringAsync()))
                    .WithResponseMessage("Success")
                    .WithStatusCode(response.StatusCode)
                    .Build();

            }
            catch (HttpRequestException e)
            {
                return new ShuffleDeckApiResponse
                {
                    StatusCode = response.StatusCode,
                    ResponseMessage = e.Message
                };
            }
        }
        /// <summary>
        /// Shuffle an API deck
        /// </summary>
        /// <param name="deckId">The deck's id returned by the API at it creation</param>
        /// <returns>The shuffle response class returned by the API</returns>
        public async Task<ShuffleDeckApiResponse> ShuffleDeckAsync(string deckId)
        {
            var response = await HttpClient.GetAsync(string.Format(ApiRouteExtensions.SHUFFLE_DECK_ROUTE, deckId));
            try
            {
                response.EnsureSuccessStatusCode();
                return new ApiResponseBuilder<ShuffleDeckApiResponse>(
                        JsonConvert.DeserializeObject<ShuffleDeckApiResponse>(
                            await response.Content.ReadAsStringAsync()))
                    .WithResponseMessage("Success")
                    .WithStatusCode(response.StatusCode)
                    .Build();

            }
            catch (HttpRequestException e)
            {
                return new ShuffleDeckApiResponse
                {
                    StatusCode = response.StatusCode,
                    ResponseMessage = e.Message
                };
            }
        }
        /// <summary>
        /// Draw card from an API deck
        /// </summary>
        /// <param name="deckId">The deck's id returned by the API at it creation</param>
        /// <param name="amount">The amount of card to draw</param>
        /// <returns>The draw response class</returns>
        public async Task<DrawCardsApiResponse> DrawCardsAsync(string deckId, int amount = 1)
        {
            var response = await HttpClient.GetAsync(string.Format(ApiRouteExtensions.DRAW_CARD_ROUTE, deckId, amount));
            try
            {
                response.EnsureSuccessStatusCode();
                return new ApiResponseBuilder<DrawCardsApiResponse>(
                        JsonConvert.DeserializeObject<DrawCardsApiResponse>(
                            await response.Content.ReadAsStringAsync()))
                    .WithResponseMessage("Success")
                    .WithStatusCode(response.StatusCode)
                    .Build();

            }
            catch (HttpRequestException e)
            {
                return new DrawCardsApiResponse
                {
                    StatusCode = response.StatusCode,
                    ResponseMessage = e.Message
                };
            }
        }
        /// <summary>
        /// Create new partial deck from the API
        /// </summary>
        /// <param name="cardsCodes">A couple (value, SuitType) where value is between 2-10 and A, J, Q, K</param>
        /// <returns>The shuffle response class</returns>
        public async Task<ShuffleDeckApiResponse> CreateNewPartialDeckAsync(IEnumerable<string> cardsCodes)
        {
            var response =
                await HttpClient.GetAsync(string.Format(ApiRouteExtensions.NEW_PARTIAL_DECK_ROUTE, string.Join(',', cardsCodes)));
            try
            {
                response.EnsureSuccessStatusCode();
                return new ApiResponseBuilder<ShuffleDeckApiResponse>(
                        JsonConvert.DeserializeObject<ShuffleDeckApiResponse>(
                            await response.Content.ReadAsStringAsync()))
                    .WithResponseMessage("Success")
                    .WithStatusCode(response.StatusCode)
                    .Build();

            }
            catch (HttpRequestException e)
            {
                return new ShuffleDeckApiResponse
                {
                    StatusCode = response.StatusCode,
                    ResponseMessage = e.Message
                };
            }
        }
    }
}