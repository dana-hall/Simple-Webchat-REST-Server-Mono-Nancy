namespace webchat.DTO.Requests
{
    public class CreateRequestMessage : IRequestMessage
    {
        public CreateRequestMessage() { }
        public CreateRequestMessage(string from, string to, string date, string message)
        {
            this.from = from;
            this.to = to;
            this.date = date;
            this.message = message;
        }
        public string from { get; set; }
        public string to { get; set; }
        public string date { get; set; }
        public string message { get; set; }
    }
}