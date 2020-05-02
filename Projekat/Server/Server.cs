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
            var repo = new KapetanRepository(new ModelContext());
            var guid = Guid.NewGuid();
            repo.Add(new Common.Models.Kapetan("1234567890321", "Test", "Test", "Muski", DateTime.Now), guidBrodskaLinija, guidBrod);
            Console.WriteLine(repo.Get("1234567890321").ToString());
            foreach (var item in repo.GetAll())
            {
                Console.WriteLine(item.ToString());
            }
            repo.Update(new Common.Models.Kapetan("1234567890321", "Test Edit", "Test Edit", "Zenski", DateTime.Now.AddYears(100)));
        }
    }
}
