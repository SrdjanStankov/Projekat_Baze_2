using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Server.Repositories
{
    public class TeretniBrodRepository
    {
        private readonly Projekat_Entities ctx;

        public TeretniBrodRepository(Projekat_Entities context)
        {
            ctx = context;
        }

        public bool Add(Common.Models.TeretniBrod item, Guid idBrodogradilista)
        {
            if (ctx.Teretni_Brod.FirstOrDefault((b) => item.ID == b.IDBroda) != null)
            {
                return false;
            }

            var brodo = ctx.Brodogradiliste.FirstOrDefault((b) => b.IDBrodog == idBrodogradilista);
            if (brodo is null)
            {
                return false;
            }

            ctx.Teretni_Brod.Add(new Teretni_Brod()
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
                KapacTeret = item.KapacTeret,
                StatUtov = item.StatUtov
            });
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public Common.Models.TeretniBrod Get(Guid idBroda)
        {
            var brod = ctx.Teretni_Brod.AsNoTracking().FirstOrDefault((item) => item.IDBroda == idBroda);
            return new Common.Models.TeretniBrod(brod.IDBroda, brod.Brod.Ime, brod.Brod.GodGrad, brod.Brod.MaxBrzina.Value, brod.Brod.Duzina.Value, brod.Brod.Sirina.Value, brod.KapacTeret.Value, brod.StatUtov);
        }

        public IEnumerable<Common.Models.TeretniBrod> GetAll()
        {
            var ret = new HashSet<Common.Models.TeretniBrod>();
            Guid previous = Guid.Empty;
            foreach (var item in ctx.SelectTeretniBrodAndMornar())
            {
                if (previous == item.IDBroda)
                {
                    continue;
                }
                previous = item.IDBroda;
                _ = ret.Add(new Common.Models.TeretniBrod(item.IDBroda, item.Brod.Ime, item.Brod.GodGrad, item.Brod.MaxBrzina.Value, item.Brod.Duzina.Value, item.Brod.Sirina.Value, item.KapacTeret.Value, item.StatUtov)
                {
                    Mornari = new HashSet<Common.Models.Mornar>(item.Mornar.Select(m => new Common.Models.Mornar(m.JMBG, m.Ime, m.Prezime, m.Pol, m.Rank)))
                });
            }
            return ret;
        }

        public void Update(Common.Models.TeretniBrod item)
        {
            var terBrod = ctx.Teretni_Brod.FirstOrDefault((b) => b.IDBroda == item.ID);
            var brod = ctx.Brod.FirstOrDefault((b) => b.IDBroda == item.ID);
            ctx.Entry(terBrod).CurrentValues.SetValues(item);
            ctx.Entry(brod).CurrentValues.SetValues(item);
            ctx.SaveChanges();
        }

        public void Remove(Guid idBroda)
        {
            ctx.Teretni_Brod.Remove(ctx.Teretni_Brod.FirstOrDefault((item) => item.IDBroda == idBroda));
            ctx.SaveChanges();
        }

        ~TeretniBrodRepository()
        {
            ctx.Dispose();
        }
    }
}
