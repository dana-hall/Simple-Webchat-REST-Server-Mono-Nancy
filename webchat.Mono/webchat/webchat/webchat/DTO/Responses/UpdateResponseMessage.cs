using System;
using webchat.DTO.Requests;
using webchat.DTO.Helpers;
using MongoDB.Bson;

namespace webchat.DTO.Responses
{
    public class UpdateResponseMessage : IResponseMessage
    {
        public UpdateResponseMessage()
        {
        }
        public UpdateResponseMessage(Enum status, string id, UpdateRequestMessage req, Object mongoResult)
        {
            this.id = id;
            this.request = req;
            if (mongoResult == null)
            {
                this.result = new Result(Status.OPERATION.UPDATE, Status.STATUS.NOT_FOUND, 0, mongoResult.ToString().Replace('"', '\''));
            }
            else
            {
                this.result = new Result(Status.OPERATION.UPDATE, status, 1, mongoResult.ToString().Replace('"', '\''));
            }
        }
        public string id { get; set; }
        public UpdateRequestMessage request { get; set; }
        public Result result { get; set; }
    }
}