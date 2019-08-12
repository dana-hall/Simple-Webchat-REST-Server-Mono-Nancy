using System;
using Nancy;
using Nancy.ModelBinding;
using webchat.Service;
using webchat.DTO.Requests;

/////////////////////////////////////////////////////////////////////////////////////////////
// References:
//
// https://auth0.com/blog/meet-nancy-a-lightweight-web-framework-for-dot-net/
// https://volkanpaksoy.com/archive/2015/11/11/building-a-simple-http-server-with-nancy/
// https://ivankahl.com/enabling-cors-in-nancy/
/////////////////////////////////////////////////////////////////////////////////////////////

namespace webchat
{
    public class WebChatController : NancyModule
    {
        String baseRoute = "/webchat";
        private readonly IWebChatService service;


        public WebChatController(IWebChatService service)
        {
            this.service = service;

            // Enable cors
            After.AddItemToEndOfPipeline((ctx) =>
            {
                ctx.Response.WithHeader("Access-Control-Allow-Origin", "*")
                    .WithHeader("Access-Control-Allow-Methods", "POST, GET, DELETE, PUT")
                    .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");
            });

            // this.service = new WebChatService(new MessageDAO());

            Get(baseRoute + "/read/all/{name}", args =>
            {
                Console.WriteLine($"/read/all/{args.name}");
                return service.fetchUserMessages(args.name);
            });

            Get(baseRoute + "/read/from/{name}", args =>
            {
                Console.WriteLine($"/read/from/{args.name}");
                return service.fetchMessagesFromUser(args.name);
            });

            Get(baseRoute + "/read/from/{fromUser}/to/{toUser}", args =>
            {
                Console.WriteLine($"/read/from/{args.fromUser}/to/{args.toUser}");
                return service.fetchMessagesFromUserToUser(args.fromUser, args.toUser);
            });

            Get(baseRoute + "/read", args =>
            {
                Console.WriteLine($"/read");
                return service.fetchAllMessages();
            });

            Post(baseRoute + "/create", args =>
            {
                Console.WriteLine($"/create");
                return service.createMessage(this.Bind<CreateRequestMessage>());
            });

            Post(baseRoute + "/delete", args =>
            {
                Console.WriteLine($"/delete");
                return service.deleteMessages(this.Bind<DeleteRequestMessage>());
            });

            Delete(baseRoute + "/delete", args =>
            {
                Console.WriteLine($"/delete");
                return service.deleteMessages(this.Bind<DeleteRequestMessage>());
            });

            Post(baseRoute + "/update/{id}", args =>
            {
                Console.WriteLine($"/update/{args.id}");
                return service.updateMessage(args.id, this.Bind<UpdateRequestMessage>());
            });

            Put(baseRoute + "/update/{id}", args =>
            {
                Console.WriteLine($"/update/{args.id}");
                return service.updateMessage(args.id, this.Bind<UpdateRequestMessage>());
            });

        }
    }
}
