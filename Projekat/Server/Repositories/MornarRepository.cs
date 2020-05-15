using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Server.Repositories
{
    public class MornarRepository
    {
        private readonly ModelContext ctx;

        public MornarRepository(ModelContext context)
        {
            ctx = context;
        }

        public bool Add(Common.Models.Mornar item)
        {
            if (ctx.Mornar.FirstOrDefault((m) => item.JMBG == m.JMBG) != null)
            {
                return false;
            }

            ctx.Mornar.Add(new Mornar()
            {
                JMBG = item.JMBG,
                Ime = item.Ime,
                Prezime = item.Prezime,
                Pol = item.Pol.ToString(),
                Rank = item.Rank
            });
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public Common.Models.Mornar Get(string jmbg)
        {
            var mornar = ctx.Mornar.Include((m) => m.Posada).AsNoTracking().FirstOrDefault((item) => item.JMBG == jmbg);
            var mornar1 = new Common.Models.Mornar(mornar.JMBG, mornar.Ime, mornar.Prezime, mornar.Pol, mornar.Rank);
            if(mornar.Posada != null)
            {
                mornar1.Posada = new Common.Models.Posada(mornar.Posada.ID, mornar.Posada.Ime, mornar.Posada.Kapacitet.Value);
            }
            return mornar1;
        }

        public IEnumerable<Common.Models.Mornar> GetAll()
        {
            var ret = new List<Common.Models.Mornar>();
            ctx.Mornar.Include((m) => m.Posada).AsNoTracking().ToList().ForEach((item) =>
            {
                var moranr = new Common.Models.Mornar(item.JMBG, item.Ime, item.Prezime, item.Pol, item.Rank);
                if (item.Posada != null)
                {
                    moranr.Posada = new Common.Models.Posada(item.Posada.ID, item.Posada.Ime, item.Posada.Kapacitet.Value);
                }
                ret.Add(moranr);
            });
            return ret;
        }

        public void Update(Common.Models.Mornar item)
        {
            var mornar = ctx.Mornar.FirstOrDefault((mor) => mor.JMBG == item.JMBG);
            ctx.Entry(mornar).CurrentValues.SetValues(item);
            ctx.SaveChanges();
        }

        public void Remove(string jmbg)
        {
            ctx.Mornar.Remove(ctx.Mornar.FirstOrDefault((item) => item.JMBG == jmbg));
            ctx.SaveChanges();
        }

        public void AddPosada(string jmbg, Guid posadaId)
        {
            var mornar = ctx.Mornar.FirstOrDefault((m) => m.JMBG == jmbg);
            var posada = ctx.Posada.FirstOrDefault((p) => p.ID == posadaId);
            mornar.Posada = posada;
            ctx.SaveChanges();
        }

        ~MornarRepository()
        {
            ctx.Dispose();
        }
    }
}
