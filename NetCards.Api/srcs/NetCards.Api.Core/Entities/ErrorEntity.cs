using NetCards.Api.Core.Enums;

namespace NetCards.Api.Core.Entities
{
    public class ErrorEntity
    {
        public ErrorCode Status { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}