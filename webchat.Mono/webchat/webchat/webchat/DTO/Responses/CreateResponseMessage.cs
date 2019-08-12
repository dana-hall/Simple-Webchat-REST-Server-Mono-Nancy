using System;
using webchat.DTO.Requests;
using webchat.DTO.Helpers;
using webchat.Models;

namespace webchat.DTO.Responses
{
    public class CreateResponseMessage : IResponseMessage
    {
        public CreateResponseMessage()
        {
        }
        public CreateResponseMessage(Enum status, CreateRequestMessage req, Message message, Object mongoResult)
        {
            this.message = message;
            this.request = req;
            this.result = new Result(Status.OPERATION.CREATE, status, 1, mongoResult);
        }
        public Message message { get; set; }
        public CreateRequestMessage request { get; set; }
        public Result result { get; set; }
    }
}