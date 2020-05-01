using System;
using System.ServiceModel;

namespace Server
{
    internal class Program
    {
        private static ServiceHost host;

        private static void Main()
        {
            Console.WriteLine("Server is starting . . .");
            host = new ServiceHost(typeof(Server));
            host.Open();
            Console.WriteLine(host.BaseAddresses.Count);
            Console.WriteLine("Server started!");
            Console.ReadLine();
            Console.WriteLine("Server is closing . . .");
            host.Close();
            Console.WriteLine("Server closed!");
            Console.ReadLine();
        }
    }
}
