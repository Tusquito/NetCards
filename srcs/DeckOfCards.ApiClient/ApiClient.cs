﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DeckOfCards.Client.Builders;
using DeckOfCards.Client.Enums;
using DeckOfCards.Client.Extensions;
using DeckOfCards.Client.Responses;
using Newtonsoft.Json;

namespace DeckOfCards.Client
{
    public class ApiClient
    {
        private static readonly HttpClient HttpClient = new();

        public ApiClient()
        {
            HttpClient.BaseAddress = new Uri(ApiRouteExtensions.BASE_ROUTE);
        }

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

        public async Task<ShuffleDeckApiResponse> CreateNewPartialDeckAsync(IEnumerable<(char, SuitType)> cardsCodes)
        {
            var routeParam = cardsCodes.Aggregate("", (x, y) => $"{x},{y.Item1}{y.Item2.ToString().Take(1)}");
            var response =
                await HttpClient.GetAsync(string.Format(ApiRouteExtensions.NEW_PARTIAL_DECK_ROUTE, routeParam));
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