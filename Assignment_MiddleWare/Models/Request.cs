namespace Assignment_MiddleWare.Models
{
    public class Request 
    {
        public string? Schema { get; set; }
        public string? Host { get; set; }
        public string? Path { get; set; }
        public string? QueryString { get; set; }
        public string? RequestBody { get; set; }
    }
}
