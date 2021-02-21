using System.Net;
using DeckOfCards.Api.Responses;

namespace DeckOfCards.Api.Builders
{
    /// <summary>
    /// API response builder that allows to add StatusCode & ResponseMessage parameters easily
    /// </summary>
    /// <typeparam name="T">IApiResponse</typeparam>
    public class ApiResponseBuilder<T> where T : IApiResponse
    {
        private T _apiResponse;
        /// <summary>
        /// Constructor: Create a new instance of ApiResponseBuilder class
        /// </summary>
        /// <param name="apiResponse">The attribute response class that has to be built</param>
        public ApiResponseBuilder(T apiResponse)
        {
            _apiResponse = apiResponse;
        }
        
        /// <summary>
        /// Add response message to the current response class
        /// </summary>
        /// <param name="message">The string message</param>
        /// <returns></returns>
        public ApiResponseBuilder<T> WithResponseMessage(string message)
        {
            _apiResponse.ResponseMessage = message;
            return this;
        }
        /// <summary>
        /// Add status code to the current response class
        /// </summary>
        /// <param name="statusCode">The status code</param>
        /// <returns></returns>
        public ApiResponseBuilder<T> WithStatusCode(HttpStatusCode statusCode)
        {
            _apiResponse.StatusCode = statusCode;
            return this;
        }
        /// <summary>
        /// Build the current response class
        /// </summary>
        /// <returns>The current response class</returns>
        public T Build()
        {
            return _apiResponse;
        }
        
    }
}