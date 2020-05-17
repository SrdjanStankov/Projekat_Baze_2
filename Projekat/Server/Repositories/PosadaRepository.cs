using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Server.Repositories
{
    public class PosadaRepository
    {
        private readonly Projekat_Entities ctx;

        public PosadaRepository(Projekat_Entities context)
        {
            ctx = context;
        }

        public bool Add(Common.Models.Posada item, string jmbgKormilar, string jmbgKapetan, Guid idBroda)
        {
            if (ctx.Posada.FirstOrDefault((b) => item.ID == b.ID) != null)
            {
                return false;
            }

            if (ctx.Posada.FirstOrDefault((p) => p.JMBG_Kormilar == jmbgKormilar) != null)
            {
                return false;
            }

            if (ctx.Posada.FirstOrDefault((p) => p.JMBG_Kapetan == jmbgKapetan) != null)
            {
                return false;
            }

            if (ctx.Posada.FirstOrDefault((p) => p.IDBroda == idBroda) != null)
            {
                return false;
            }

            var kormilar = ctx.Kormilar.FirstOrDefault((k) => k.JMBG == jmbgKormilar);
            if (kormilar is null)
            {
                return false;
            }

            var kapetan = ctx.Kapetan.FirstOrDefault((k) => k.JMBG == jmbgKapetan);
            if (kapetan is null)
            {
                return false;
            }

            var brod = ctx.Brod.FirstOrDefault((b) => b.IDBroda == idBroda);
            if (brod is null)
            {
                return false;
            }

            var entity = new Posada()
            {
                ID = item.ID,
                Ime = item.Ime,
                Kapacitet = item.Kapacitet,
                Kormilar = kormilar,
                Kapetan = kapetan,
                Brod = brod
            };
            ctx.Posada.Add(entity);
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public Common.Models.Posada Get(Guid idPosade)
        {
            var posada = ctx.Posada.AsNoTracking().FirstOrDefault((item) => item.ID == idPosade);
            return new Common.Models.Posada(posada.ID, posada.Ime, posada.Kapacitet.Value);
        }

        public IEnumerable<Common.Models.Posada> GetAll()
        {
            var ret = new HashSet<Common.Models.Posada>();
            Guid previous = Guid.Empty;
            foreach (var item in ctx.SelectPosadaAndMornar())
            {
                if (previous == item.ID)
                {
                    continue;
                }
                previous = item.ID;
                _ = ret.Add(new Common.Models.Posada(item.ID, item.Ime, item.Kapacitet.Value)
                {
                    Brod = new Common.Models.Brod(item.Brod.IDBroda, item.Brod.Ime, item.Brod.GodGrad, item.Brod.MaxBrzina.Value, item.Brod.Duzina.Value, item.Brod.Sirina.Value),
                    Kapetan = new Common.Models.Kapetan(item.Kapetan.JMBG, item.Kapetan.Ime, item.Kapetan.Prezime, item.Kapetan.Pol, item.Kapetan.GodRodj.Value),
                    Kormilar = new Common.Models.Kormilar(item.Kormilar.JMBG, item.Kormilar.Ime, item.Kormilar.Prezime, item.Kormilar.Pol),
                    Mornari = new HashSet<Common.Models.Mornar>(item.Mornar.Select((m) => new Common.Models.Mornar(m.JMBG, m.Ime, m.Prezime, m.Pol, m.Rank)))
                });
            }
            return ret;
        }

        public void Update(Common.Models.Posada item)
        {
            var posada = ctx.Posada.FirstOrDefault((b) => b.ID == item.ID);
            ctx.Entry(posada).CurrentValues.SetValues(item);
            ctx.SaveChanges();
        }

        public void Remove(Guid idPosade)
        {
            ctx.Posada.Remove(ctx.Posada.FirstOrDefault((item) => item.ID == idPosade));
            ctx.SaveChanges();
        }

        ~PosadaRepository()
        {
            ctx.Dispose();
        }
    }
}
