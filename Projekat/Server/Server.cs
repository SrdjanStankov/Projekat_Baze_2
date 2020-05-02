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
            var guidTeretniBrod = Guid.Parse("a5fc38ba-8bf3-4b41-89d3-775f90ed9e2b");
            var guidKormilar = "1234567890123";
            var guidKapetan = "1234567890321";
            var repo = new BrodogradilisteRepository(new ModelContext());
            var guid = Guid.NewGuid();
            //repo.Add(new Common.Models.Posada(guid, "Test", 10), guidKormilar, guidKapetan, guidBrod);
            //Console.WriteLine(repo.Get(guid).ToString());
            //foreach (var item in repo.GetAll())
            //{
            //    Console.WriteLine(item.ToString());
            //}
            repo.Update(new Common.Models.Brodogradiliste(guidBrodogradiliste, "Test Edit", "Test Edit", 250, 350, false));
        }
    }
}
