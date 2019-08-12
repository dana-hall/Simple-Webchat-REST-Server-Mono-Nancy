namespace webchat.Models
{
    public class Message : IMessage
    {
        public Message()
        {
            this.__v = "0";
        }
        public Message(string from, string to, string date, string message)
        {
            this.from = from;
            this.to = to;
            this.date = date;
            this.message = message;
            this.__v = "0";
        }

        [MongoDB.Bson.Serialization.Attributes.BsonId]
        public string id { get; set; }

        public string from { get; set; }

        public string to { get; set; }

        public string date { get; set; }

        public string message { get; set; }

        public string __v { get; set; }

    }
}