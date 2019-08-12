using System;
using Nancy.Hosting.Self;

namespace webchat
{
    class WebChat
    {
        public static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:8070")))
            {
                host.Start();

                Console.WriteLine("NancyFX Stand alone WebChat application.");
                Console.WriteLine("Press enter to exit the application");
                Console.ReadLine();
            }
        }
    }
}
