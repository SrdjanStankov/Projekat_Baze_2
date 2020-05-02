using System;
using Common;

namespace Server
{
    public class Server : ICommunication
    {
        public void Comunicate()
        {
            var guidBrodogradiliste = Guid.Parse("554aacd2-3b83-4973-88f1-76007b3b3d6b");
            var repo = new BrodskaLinijaRepository(new ModelContext());
            var guid = Guid.NewGuid();
            repo.Add(new Common.Models.BrodskaLinija(guid, "Test", "Test", "Test", "Test"));
            Console.WriteLine(repo.Get(guid).ToString());
            foreach (var item in repo.GetAll())
            {
                Console.WriteLine(item.ToString());
            }
            repo.Update(new Common.Models.BrodskaLinija(guid, "Test Edit", "Test Edit", "Test Edit", "Test Edit"));
        }
    }
}
