using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Repositories
{
    public class TankerRepository
    {
        private readonly ModelContext ctx;

        public TankerRepository(ModelContext context)
        {
            ctx = context;
        }

        public bool Add(Common.Models.Tanker item, Guid idBrodogradilista)
        {
            if (ctx.Tanker.FirstOrDefault((b) => item.ID == b.IDBroda) != null)
            {
                return false;
            }

            var brodo = ctx.Brodogradiliste.FirstOrDefault((b) => b.IDBrodog == idBrodogradilista);
            if (brodo is null)
            {
                return false;
            }

            ctx.Tanker.Add(new Tanker()
            {
                Brod = new Brod()
                {
                    IDBroda = item.ID,
                    Ime = item.Ime,
                    GodGrad = item.GodGrad,
                    Duzina = item.Duzina,
                    MaxBrzina = item.MaxBrzina,
                    Sirina = item.Sirina,
                    Brodogradiliste = brodo
                },
                Nosivost = item.Nosivost,
                TipTeret = item.TipTeret
            });
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public Common.Models.Tanker Get(Guid idBroda)
        {
            var brod = ctx.Tanker.AsNoTracking().FirstOrDefault((item) => item.IDBroda == idBroda);
            return new Common.Models.Tanker(brod.IDBroda, brod.Brod.Ime, brod.Brod.GodGrad, brod.Brod.MaxBrzina.Value, brod.Brod.Duzina.Value, brod.Brod.Sirina.Value, brod.Nosivost.Value, brod.TipTeret);
        }

        public IEnumerable<Common.Models.Tanker> GetAll()
        {
            var ret = new List<Common.Models.Tanker>();
            ctx.Tanker.AsNoTracking().ToList().ForEach((item) =>
            {
                ret.Add(new Common.Models.Tanker(item.IDBroda, item.Brod.Ime, item.Brod.GodGrad, item.Brod.MaxBrzina.Value, item.Brod.Duzina.Value, item.Brod.Sirina.Value, item.Nosivost.Value, item.TipTeret));
            });
            return ret;
        }

        public void Update(Common.Models.Tanker item)
        {
            var tanker = ctx.Tanker.FirstOrDefault((b) => b.IDBroda == item.ID);
            var brod = ctx.Brod.FirstOrDefault((b) => b.IDBroda == item.ID);
            ctx.Entry(tanker).CurrentValues.SetValues(item);
            ctx.Entry(brod).CurrentValues.SetValues(item);
            ctx.SaveChanges();
        }

        public void Remove(Guid idBroda)
        {
            ctx.Tanker.Remove(ctx.Tanker.FirstOrDefault((item) => item.IDBroda == idBroda));
            ctx.SaveChanges();
        }

        ~TankerRepository()
        {
            ctx.Dispose();
        }
    }
}
