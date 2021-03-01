using NetCards.Api.Core.Entities;
using Newtonsoft.Json;

namespace NetCards.Api.Core.Responses
{
    public class BasicResponse
    {
        public BasicResponse(ErrorEntity error)
        {
            Error = error;
        }

        public BasicResponse(IResponse response)
        {
            Data = response;
        }
        
        [JsonProperty("data")]
        public IResponse Data { get; set; }
        [JsonProperty("error")]
        public ErrorEntity Error { get; set; }
    }
}