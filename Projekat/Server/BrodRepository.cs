using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    public class BrodRepository
    {
        private readonly ModelContext ctx;

        public BrodRepository(ModelContext context)
        {
            ctx = context;
        }

        public bool Add(Common.Models.Brod item, Guid idBrodogradilista)
        {
            if (ctx.Brod.FirstOrDefault((b) => item.ID == b.IDBroda) != null)
            {
                return false;
            }

            var brodo = ctx.Brodogradiliste.FirstOrDefault((b) => b.IDBrodog == idBrodogradilista);
            if (brodo is null)
            {
                return false;
            }

            ctx.Brod.Add(new Brod()
            {
                IDBroda = item.ID,
                Ime = item.Ime,
                GodGrad = item.GodGrad,
                MaxBrzina = item.MaxBrzina,
                Duzina = item.Duzina,
                Sirina = item.Sirina,
                Brodogradiliste = brodo
            });
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public Common.Models.Brod Get(Guid id)
        {
            var brod = ctx.Brod.AsNoTracking().FirstOrDefault((item) => item.IDBroda == id);
            return new Common.Models.Brod(brod.IDBroda, brod.Ime, brod.GodGrad, brod.MaxBrzina.Value, brod.Duzina.Value, brod.Sirina.Value);
        }

        public IEnumerable<Common.Models.Brod> GetAll()
        {
            var ret = new List<Common.Models.Brod>();
            ctx.Brod.AsNoTracking().ToList().ForEach((item) =>
            {
                ret.Add(new Common.Models.Brod(item.IDBroda, item.Ime, item.GodGrad, item.MaxBrzina.Value, item.Duzina.Value, item.Sirina.Value));
            });
            return ret;
        }

        public void Update(Common.Models.Brod item)
        {
            var brod = ctx.Brod.FirstOrDefault((b) => b.IDBroda == item.ID);
            ctx.Entry(brod).CurrentValues.SetValues(item);
            ctx.SaveChanges();
        }

        public void Remove(Guid id)
        {
            ctx.Brod.Remove(ctx.Brod.FirstOrDefault((item) => item.IDBroda == id));
            ctx.SaveChanges();
        }

        ~BrodRepository()
        {
            ctx.Dispose();
        }
    }
}
