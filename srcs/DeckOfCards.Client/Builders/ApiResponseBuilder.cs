using System.Net;
using System.Net.Mime;
using DeckOfCards.Client.Responses;

namespace DeckOfCards.Client.Builders
{
    public class ApiResponseBuilder<T> where T : IApiResponse
    {
        private T _apiResponse;
        public ApiResponseBuilder(T apiResponse)
        {
            _apiResponse = apiResponse;
        }

        public ApiResponseBuilder<T> WithResponseMessage(string message)
        {
            _apiResponse.ResponseMessage = message;
            return this;
        }

        public ApiResponseBuilder<T> WithStatusCode(HttpStatusCode statusCode)
        {
            _apiResponse.StatusCode = statusCode;
            return this;
        }

        public T Build()
        {
            return _apiResponse;
        }
        
    }
}