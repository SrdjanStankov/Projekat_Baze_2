using System;
using Common;

namespace Server
{
    public class Server : ICommunication
    {
        public void Comunicate()
        {
            var mornarRepo = new MornarRepository(new ModelContext());
            mornarRepo.Add(new Common.Models.Mornar("1234567890123", "Test", "Test", "Muski", "Test"));
            Console.WriteLine(mornarRepo.Get("1234567890123").ToString());
            foreach (var item in mornarRepo.GetAll())
            {
                Console.WriteLine(item.ToString());
            }
            mornarRepo.Update(new Common.Models.Mornar("1234567890123", "Test Edit", "Test Edit", "Zenski", "Test Edit"));
        }
    }
}
