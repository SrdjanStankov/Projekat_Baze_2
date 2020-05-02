using System;
using Common;

namespace Server
{
    public class Server : ICommunication
    {
        public void Comunicate()
        {
            var repo = new BrodogradilisteRepository(new ModelContext());
            var guid = Guid.NewGuid();
            repo.Add(new Common.Models.Brodogradiliste(guid, "Test", "Test", 200, 300, true));
            Console.WriteLine(repo.Get(guid).ToString());
            foreach (var item in repo.GetAll())
            {
                Console.WriteLine(item.ToString());
            }
            repo.Update(new Common.Models.Brodogradiliste(guid, "Test Edit", "Test Edit", 250, 350, false));
        }
    }
}
