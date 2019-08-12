using System;
using System.Collections.Generic;
using webchat.Models;
using webchat.Mapper;
using MongoDB.Bson;
using MongoDB.Driver;
using webchat.DTO.Requests;
using webchat.DTO.Responses;
using webchat.DTO.Helpers;
using System.Configuration;

namespace webchat.DAO
{
    public class MessageDAO : IMessageDAO
    {
        private IMongoCollection<BsonDocument> col;

        public MessageDAO()
        {
            // Get configuration info from appsettings.json
            var url = ConfigurationManager.AppSettings.Get("url");
            var port = ConfigurationManager.AppSettings.Get("port");
            var database = ConfigurationManager.AppSettings.Get("database");
            var document = ConfigurationManager.AppSettings.Get("document");
            var connection = "mongodb://" + url + ":" + port;

            // Create connection
            var client = new MongoClient(connection);
            var db = client.GetDatabase(database);
            this.col = db.GetCollection<BsonDocument>(document);
        }
        //
        // Create a message
        //
        public CreateResponseMessage createMessage(CreateRequestMessage msg)
        {
            CreateResponseMessage response;
            Message message = MessageMapper.toMessage(msg);
            BsonDocument doc = MessageMapper.toBsonDocument(message);

            try
            {
                col.InsertOne(doc);
                message.id = doc["_id"].ToString();
                response = new CreateResponseMessage(Status.STATUS.SUCCESS, msg, message, null);
            }
            catch (MongoWriteException err)
            {
                response = new CreateResponseMessage(Status.STATUS.ERROR, msg, message, err);
            }

            return response;
        }

        //
        // Delete all messages
        //
        public DeleteResponseMessage deleteMessages(DeleteRequestMessage req)
        {
            DeleteResult result;
            DeleteResponseMessage response;

            try
            {
                result = col.DeleteMany(m => m["from"] == req.from && m["to"] == req.to);
                response = new DeleteResponseMessage(Status.STATUS.SUCCESS, req, result);
            }
            catch (MongoWriteException err)
            {
                response = new DeleteResponseMessage(Status.STATUS.ERROR, req, err);
            }

            return response;
        }

        //
        // Update a message
        //
        public UpdateResponseMessage updateMessage(String id, UpdateRequestMessage req)
        {
            UpdateResponseMessage response;
            ObjectId oid = new ObjectId(id);

            try
            {
                var filter = new BsonDocument("_id", oid);
                var update = Builders<BsonDocument>.Update
                                            .Set("from", req.from)
                                            .Set("to", req.to)
                                            .Set("date", req.date)
                                            .Set("message", req.message);
                BsonDocument result = col.FindOneAndUpdate(filter, update);
                response = new UpdateResponseMessage(Status.STATUS.SUCCESS, id, req, result);
            }
            catch (MongoWriteException err)
            {
                response = new UpdateResponseMessage(Status.STATUS.ERROR, id, req, err);
            }

            return response;
        }

        //
        // Retrieve all messages belonging to a user
        //
        public ReadResponseMessage fetchUserMessages(String user)
        {
            List<Message> messages = new List<Message>();
            ReadResponseMessage response;

            try
            {
                List<BsonDocument> documents = col.Find(m => m["from"] == user || m["to"] == user).ToList();
                foreach (var doc in documents)
                {
                    Message message = MessageMapper.toMessage(doc);
                    messages.Add(message);
                }
                response = new ReadResponseMessage(Status.STATUS.SUCCESS, messages, null);
            }
            catch (MongoWriteException err)
            {
                response = new ReadResponseMessage(Status.STATUS.ERROR, messages, err);
            }

            return response;
        }

        //
        // Retrieve all messages from a user
        //
        public ReadResponseMessage fetchMessagesFromUser(String user)
        {
            List<Message> messages = new List<Message>();
            ReadResponseMessage response;

            try
            {
                List<BsonDocument> documents = col.Find(m => m["from"] == user).ToList();
                foreach (var doc in documents)
                {
                    Message message = MessageMapper.toMessage(doc);
                    messages.Add(message);
                }
                response = new ReadResponseMessage(Status.STATUS.SUCCESS, messages, null);
            }
            catch (MongoWriteException err)
            {
                response = new ReadResponseMessage(Status.STATUS.ERROR, messages, err);
            }


            return response;
        }

        //
        // Fetch all messages from a user to a user
        //
        public ReadResponseMessage fetchMessagesFromUserToUser(String fromUser, String toUser)
        {
            List<Message> messages = new List<Message>();
            ReadResponseMessage response;

            try
            {
                List<BsonDocument> documents = col.Find(m => m["from"] == fromUser && m["to"] == toUser).ToList();
                foreach (var doc in documents)
                {
                    Message message = MessageMapper.toMessage(doc);
                    messages.Add(message);
                }
                response = new ReadResponseMessage(Status.STATUS.SUCCESS, messages, null);
            }
            catch (MongoWriteException err)
            {
                response = new ReadResponseMessage(Status.STATUS.ERROR, messages, err);
            }


            return response;
        }

        //
        // Fetch all the messages in the table
        //
        public ReadResponseMessage fetchAllMessages()
        {
            List<Message> messages = new List<Message>();
            ReadResponseMessage response;

            try
            {
                List<BsonDocument> documents = col.Find(m => true).ToList();
                foreach (var doc in documents)
                {
                    Message message = MessageMapper.toMessage(doc);
                    messages.Add(message);
                }
                response = new ReadResponseMessage(Status.STATUS.SUCCESS, messages, null);
            }
            catch (MongoWriteException err)
            {
                response = new ReadResponseMessage(Status.STATUS.ERROR, messages, err);
            }

            return response;
        }

    }
}




