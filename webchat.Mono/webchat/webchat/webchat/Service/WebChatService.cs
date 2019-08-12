using System;
using webchat.DAO;
using webchat.DTO.Requests;
using webchat.DTO.Responses;

namespace webchat.Service
{
    public class WebChatService : IWebChatService
    {
        IMessageDAO messageDao;

        public WebChatService(IMessageDAO messageDao)
        {
            this.messageDao = messageDao;
        }
        //
        // Create a message
        //
        public CreateResponseMessage createMessage(CreateRequestMessage req)
        {

            CreateResponseMessage response = messageDao.createMessage(req);

            return response;
        }

        //
        // Update a message
        //
        public UpdateResponseMessage updateMessage(String id, UpdateRequestMessage req)
        {

            UpdateResponseMessage response = messageDao.updateMessage(id, req);

            return response;
        }

        //
        // Delete all messages
        //
        public DeleteResponseMessage deleteMessages(DeleteRequestMessage req)
        {

            DeleteResponseMessage response = messageDao.deleteMessages(req);

            return response;
        }
        //
        // Retrieve all messages belonging to a user
        //
        public ReadResponseMessage fetchUserMessages(String user)
        {

            ReadResponseMessage response = messageDao.fetchUserMessages(user);

            return response;
        }

        //
        // Retrieve all messages from a user
        //
        public ReadResponseMessage fetchMessagesFromUser(String user)
        {

            ReadResponseMessage response = messageDao.fetchMessagesFromUser(user);

            return response;
        }

        //
        // Fetch all messages from a user to a user
        //
        public ReadResponseMessage fetchMessagesFromUserToUser(String fromUser, String toUser)
        {

            ReadResponseMessage response = messageDao.fetchMessagesFromUserToUser(fromUser, toUser);

            return response;
        }

        //
        // Fetch all the messages in the table
        //
        public ReadResponseMessage fetchAllMessages()
        {
            ReadResponseMessage response = messageDao.fetchAllMessages();

            return response;
        }
    }
}
