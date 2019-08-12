using System;
using webchat.DTO.Requests;
using webchat.DTO.Helpers;

namespace webchat.DTO.Responses
{
    public class DeleteResponseMessage : IResponseMessage
    {
        public DeleteResponseMessage(Enum status, DeleteRequestMessage request, Object mongoResult)
        {
            this.request = request;
            this.result = new Result(Status.OPERATION.DELETE, status, -1, mongoResult);
        }
        public DeleteRequestMessage request { get; set; }
        public Result result { get; set; }
    }
}