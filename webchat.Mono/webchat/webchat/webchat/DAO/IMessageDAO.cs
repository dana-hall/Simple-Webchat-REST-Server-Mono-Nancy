using System;
using System.Collections.Generic;
using webchat.DTO.Requests;
using webchat.DTO.Responses;
using webchat.DTO.Helpers;

namespace webchat.DAO
{
    public interface IMessageDAO
    {
        //
        // Create a message
        //
        CreateResponseMessage createMessage(CreateRequestMessage message);

        //
        // Delete all messages
        //
        DeleteResponseMessage deleteMessages(DeleteRequestMessage req);

        //
        // Update a message
        //
        UpdateResponseMessage updateMessage(String id, UpdateRequestMessage req);

        //
        // Retrieve all messages belonging to a user
        //
        ReadResponseMessage fetchUserMessages(String user);

        //
        // Retrieve all messages from a user
        //
        ReadResponseMessage fetchMessagesFromUser(String user);

        //
        // Fetch all messages from a user to a user
        //
        ReadResponseMessage fetchMessagesFromUserToUser(String fromUser, String toUser);

        //
        // Fetch all the messages in the table
        //
        ReadResponseMessage fetchAllMessages();

    }
}

