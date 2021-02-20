using System.Net;

namespace DeckOfCards.Client.Responses
{
    public interface IApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}