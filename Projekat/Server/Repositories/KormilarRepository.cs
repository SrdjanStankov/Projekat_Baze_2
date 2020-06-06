using System.Collections.Generic;
using System.Linq;

namespace Server.Repositories
{
    public class KormilarRepository
    {
        private readonly Projekat_Entities ctx;

        public KormilarRepository(Projekat_Entities context)
        {
            ctx = context;
        }

        public bool Add(Common.Models.Kormilar item)
        {
            if (ctx.Kormilar.FirstOrDefault((k) => item.JMBG == k.JMBG) != null)
            {
                return false;
            }

            ctx.Kormilar.Add(new Kormilar()
            {
                JMBG = item.JMBG,
                Ime = item.Ime,
                Prezime = item.Prezime,
                Pol = item.Pol.ToString()
            });
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public Common.Models.Kormilar Get(string jmbg)
        {
            var m = ctx.Kormilar.AsNoTracking().FirstOrDefault((item) => item.JMBG == jmbg);
            return new Common.Models.Kormilar(m.JMBG, m.Ime, m.Prezime, m.Pol);
        }

        public IEnumerable<Common.Models.Kormilar> GetAll()
        {
            var ret = new List<Common.Models.Kormilar>();
            ctx.Kormilar.AsNoTracking().ToList().ForEach((item) =>
            {
                ret.Add(new Common.Models.Kormilar(item.JMBG, item.Ime, item.Prezime, item.Pol));
            });
            return ret;
        }

        public void Update(Common.Models.Kormilar item)
        {
            var kormilar = ctx.Kormilar.FirstOrDefault((korm) => korm.JMBG == item.JMBG);
            ctx.Entry(kormilar).CurrentValues.SetValues(item);
            ctx.SaveChanges();
        }

        public bool Remove(string jmbg)
        {
            try
            {
                ctx.Kormilar.Remove(ctx.Kormilar.FirstOrDefault((item) => item.JMBG == jmbg));
                ctx.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        ~KormilarRepository()
        {
            ctx.Dispose();
        }
    }
}
