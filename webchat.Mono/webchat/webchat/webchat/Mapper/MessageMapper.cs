using webchat.Models;
using MongoDB.Bson;
using webchat.DTO.Requests;

namespace webchat.Mapper
{
    public class MessageMapper
    {
        // convert Message to MongoDB BsonDocument
        public static BsonDocument toBsonDocument(Message m)
        {

            var document = new BsonDocument();
            document.Add("from", m.from);
            document.Add("to", m.to);
            document.Add("date", m.date);
            document.Add("message", m.message);
            document.Add("__v", m.__v);

            return document;
        }

        // convert BsonDocument Object to Message
        public static Message toMessage(BsonDocument doc)
        {

            Message m = new Message();

            m.id = doc.GetValue("_id").ToString();
            m.from = doc.GetValue("from").ToString();
            m.to = doc.GetValue("to").ToString();
            m.date = doc.GetValue("date").ToString();
            m.message = doc.GetValue("message").ToString();
            m.__v = doc.GetValue("__v").ToString();

            return m;
        }

        // convert CreaeteRequestMessage Object to Message
        public static Message toMessage(CreateRequestMessage message)
        {

            Message m = new Message();

            m.from = message.from;
            m.to = message.to;
            m.date = message.date;
            m.message = message.message;

            return m;
        }
    }
}