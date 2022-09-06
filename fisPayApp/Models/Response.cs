namespace fisPayApp.Models
{
    public class Response
    {
        public ResponseData resultCode { get; set; }
    }
    public class ResponseData
    {
        public string statusCode { get; set; }
        public string messageText {get; set;}
    }
}
