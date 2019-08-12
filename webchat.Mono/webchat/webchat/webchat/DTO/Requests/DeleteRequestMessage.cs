namespace webchat.DTO.Requests
{
    public class DeleteRequestMessage : IRequestMessage
    {
        public DeleteRequestMessage() { }
        public DeleteRequestMessage(string from, string to)
        {
            this.from = from;
            this.to = to;
        }
        public string from { get; set; }
        public string to { get; set; }
    }
}