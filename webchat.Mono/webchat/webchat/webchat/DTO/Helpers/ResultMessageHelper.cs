using System;

namespace webchat.DTO.Helpers
{
    public class Result
    {
        public Result() { }
        public Result(Enum operation, Enum status, int count, Object mongoResult)
        {
            this.count = count;
            this.mongoResult = mongoResult;
            switch (status)
            {
                case Status.STATUS.SUCCESS:
                    {
                        this.status = "Success";
                        this.message = "Operation Successful";
                        break;
                    }
                case Status.STATUS.NOT_FOUND:
                    {
                        this.status = "Success";
                        this.message = "No results or not found";
                        break;
                    }
                case Status.STATUS.ERROR:
                    {
                        this.status = "Error";
                        this.message = "Operation Failure";
                        break;
                    }
                default: break;
            }

            switch (operation)
            {
                case Status.OPERATION.CREATE:
                    {
                        this.operation = "Create";
                        break;
                    }
                case Status.OPERATION.READ:
                    {
                        this.operation = "Read";
                        break;
                    }
                case Status.OPERATION.UPDATE:
                    {
                        this.operation = "Update";
                        break;
                    }
                case Status.OPERATION.DELETE:
                    {
                        this.operation = "Delete";
                        break;
                    }
                default: break;
            }

        }
        public string operation { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public int count { get; set; }
        public Object mongoResult { get; set; }
    }

}