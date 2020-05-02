using System;
using Common;

namespace Server
{
    public class Server : ICommunication
    {
        public void Comunicate()
        {
            var guidBrodogradiliste = Guid.Parse("554aacd2-3b83-4973-88f1-76007b3b3d6b");
            var guidBrodskaLinija = Guid.Parse("149b33de-6767-4441-a20c-8565bd5b88ae");
            var guidBrod = Guid.Parse("1b710ca5-e677-4fff-bdfc-6f6bfa43cbc9");
            var repo = new TankerRepository(new ModelContext());
            var guid = Guid.NewGuid();
            repo.Add(new Common.Models.Tanker(guid, "Test", DateTime.Now, 100, 200, 300, 10, "Utovaruje"), guidBrodogradiliste);
            Console.WriteLine(repo.Get(guid).ToString());
            foreach (var item in repo.GetAll())
            {
                Console.WriteLine(item.ToString());
            }
            repo.Update(new Common.Models.Tanker(guid, "Test Edit", DateTime.Now.AddYears(100), 150, 250, 350, 15, "Istovaruje"));
        }
    }
}
