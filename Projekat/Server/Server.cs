using System;
using Common;

namespace Server
{
    public class Server : ICommunication
    {
        public void Comunicate()
        {
            var repo = new KormilarRepository(new ModelContext());
            repo.Add(new Common.Models.Kormilar("1234567890123", "Test", "Test", "Muski"));
            Console.WriteLine(repo.Get("1234567890123").ToString());
            foreach (var item in repo.GetAll())
            {
                Console.WriteLine(item.ToString());
            }
            repo.Update(new Common.Models.Kormilar("1234567890123", "Test Edit", "Test Edit", "Zenski"));
        }
    }
}
