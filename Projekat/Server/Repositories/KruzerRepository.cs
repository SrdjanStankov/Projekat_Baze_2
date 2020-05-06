using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Repositories
{
    public class KruzerRepository
    {
        private readonly ModelContext ctx;

        public KruzerRepository(ModelContext context)
        {
            ctx = context;
        }

        public bool Add(Common.Models.Kruzer item, Guid idBrodogradilista)
        {
            if (ctx.Kruzer.FirstOrDefault((b) => item.ID == b.IDBroda) != null)
            {
                return false;
            }

            var brodo = ctx.Brodogradiliste.FirstOrDefault((b) => b.IDBrodog == idBrodogradilista);
            if (brodo is null)
            {
                return false;
            }

            ctx.Kruzer.Add(new Kruzer()
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
                BrPutnika = item.BrPutnika,
                BrOsoblja = item.BrOsoblja
            });
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public Common.Models.Kruzer Get(Guid idBroda)
        {
            var brod = ctx.Kruzer.AsNoTracking().FirstOrDefault((item) => item.IDBroda == idBroda);
            return new Common.Models.Kruzer(brod.IDBroda, brod.Brod.Ime, brod.Brod.GodGrad, brod.Brod.MaxBrzina.Value, brod.Brod.Duzina.Value, brod.Brod.Sirina.Value, brod.BrPutnika.Value, brod.BrOsoblja.Value);
        }

        public IEnumerable<Common.Models.Kruzer> GetAll()
        {
            var ret = new List<Common.Models.Kruzer>();
            ctx.Kruzer.AsNoTracking().ToList().ForEach((item) =>
            {
                ret.Add(new Common.Models.Kruzer(item.IDBroda, item.Brod.Ime, item.Brod.GodGrad, item.Brod.MaxBrzina.Value, item.Brod.Duzina.Value, item.Brod.Sirina.Value, item.BrPutnika.Value, item.BrOsoblja.Value));
            });
            return ret;
        }

        public void Update(Common.Models.Kruzer item)
        {
            var kruzer = ctx.Kruzer.FirstOrDefault((b) => b.IDBroda == item.ID);
            var brod = ctx.Brod.FirstOrDefault((b) => b.IDBroda == item.ID);
            ctx.Entry(kruzer).CurrentValues.SetValues(item);
            ctx.Entry(brod).CurrentValues.SetValues(item);
            ctx.SaveChanges();
        }

        public void Remove(Guid idBroda)
        {
            ctx.Kruzer.Remove(ctx.Kruzer.FirstOrDefault((item) => item.IDBroda == idBroda));
            ctx.SaveChanges();
        }

        ~KruzerRepository()
        {
            ctx.Dispose();
        }
    }
}
