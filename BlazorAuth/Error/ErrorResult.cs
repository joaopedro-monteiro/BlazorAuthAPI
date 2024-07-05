using System.Net;

namespace BlazorAuth.Error
{
    public class ErrorResult
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
        public List<Error>? Errors { get; set; }
    }
}
