using System.Collections.Generic;
using System.Linq;

namespace Server
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
            var m = ctx.Mornar.AsNoTracking().FirstOrDefault((item) => item.JMBG == jmbg);
            return new Common.Models.Mornar(m.JMBG, m.Ime, m.Prezime, m.Pol, m.Rank);
        }

        public IEnumerable<Common.Models.Mornar> GetAll()
        {
            var ret = new List<Common.Models.Mornar>();
            ctx.Mornar.AsNoTracking().ToList().ForEach((item) =>
            {
                ret.Add(new Common.Models.Mornar(item.JMBG, item.Ime, item.Prezime, item.Pol, item.Rank));
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

        ~MornarRepository()
        {
            ctx.Dispose();
        }
    }
}
