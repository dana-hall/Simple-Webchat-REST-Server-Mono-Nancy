using System;
using System.Collections.Generic;
using webchat.DTO.Helpers;
using webchat.Models;

namespace webchat.DTO.Responses
{
    public class ReadResponseMessage : IResponseMessage
    {
        public ReadResponseMessage()
        {
        }
        public ReadResponseMessage(Enum status, List<Message> messages, Object mongoResult)
        {
            this.result = new Result(Status.OPERATION.READ, status, messages.Count, mongoResult);
            this.messages = messages;
        }
        public List<Message> messages { get; set; }
        public Result result { get; set; }
    }
}