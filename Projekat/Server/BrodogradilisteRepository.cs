using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    public class BrodogradilisteRepository
    {
        private ModelContext ctx;

        public BrodogradilisteRepository(ModelContext context)
        {
            ctx = context;
        }

        public void Add(Common.Models.Brodogradiliste item)
        {
            if (ctx.Brodogradiliste.FirstOrDefault((b) => item.ID == b.IDBrodog) != null)
            {
                return;
            }

            ctx.Brodogradiliste.Add(new Brodogradiliste()
            {
                IDBrodog = item.ID,
                Naziv = item.Naziv,
                Lokacija = item.Lokacija,
                BrNaprBrod = item.BrojNapravljenihBrodova,
                BrPrist = item.BrojPristanista,
                PosedSuvDok = item.PosedujeSuviDok
            });
            ctx.SaveChanges();
        }

        public Common.Models.Brodogradiliste Get(Guid id)
        {
            var brodo = ctx.Brodogradiliste.AsNoTracking().FirstOrDefault((item) => item.IDBrodog == id);
            return new Common.Models.Brodogradiliste(brodo.IDBrodog, brodo.Naziv, brodo.Lokacija, brodo.BrNaprBrod.Value, brodo.BrPrist.Value, brodo.PosedSuvDok.Value);
        }

        public IEnumerable<Common.Models.Brodogradiliste> GetAll()
        {
            var ret = new List<Common.Models.Brodogradiliste>();
            ctx.Brodogradiliste.AsNoTracking().ToList().ForEach((item) =>
            {
                ret.Add(new Common.Models.Brodogradiliste(item.IDBrodog, item.Naziv, item.Lokacija, item.BrNaprBrod.Value, item.BrPrist.Value, item.PosedSuvDok.Value));
            });
            return ret;
        }

        public void Update(Common.Models.Brodogradiliste item)
        {
            var brodo = ctx.Brodogradiliste.FirstOrDefault((b) => b.IDBrodog == item.ID);
            ctx.Entry(brodo).CurrentValues.SetValues(item);
            ctx.SaveChanges();
        }

        public void Remove(Guid id)
        {
            ctx.Brodogradiliste.Remove(ctx.Brodogradiliste.FirstOrDefault((item) => item.IDBrodog == id));
            ctx.SaveChanges();
        }

        ~BrodogradilisteRepository()
        {
            ctx.Dispose();
        }
    }
}
