using System;
using Common;

namespace Server
{
    public class Server : ICommunication
    {
        public void Comunicate()
        {
            var repo = new BrodRepository(new ModelContext());
            var guid = Guid.NewGuid();
            repo.Add(new Common.Models.Brod(guid, "Test", DateTime.Now, 200, 300, 400));
            Console.WriteLine(repo.Get(guid).ToString());
            foreach (var item in repo.GetAll())
            {
                Console.WriteLine(item.ToString());
            }
            repo.Update(new Common.Models.Brod(guid, "Test Edit", DateTime.Now.AddYears(100), 250, 350, 450));
        }
    }
}
