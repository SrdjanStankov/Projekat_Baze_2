using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class PosadaRepository
    {
        private readonly ModelContext ctx;

        public PosadaRepository(ModelContext context)
        {
            ctx = context;
        }

        public void Add(Common.Models.Posada item, string jmbgKormilar, string jmbgKapetan, Guid idBroda)
        {
            if (ctx.Posada.FirstOrDefault((b) => item.ID == b.IDBroda) != null)
            {
                return;
            }

            var kormilar = ctx.Kormilar.FirstOrDefault((k) => k.JMBG == jmbgKormilar);
            if (kormilar is null)
            {
                return;
            }

            var kapetan = ctx.Kapetan.FirstOrDefault((k) => k.JMBG == jmbgKapetan);
            if (kapetan is null)
            {
                return;
            }

            var brod = ctx.Brod.FirstOrDefault((b) => b.IDBroda == idBroda);
            if (brod is null)
            {
                return;
            }

            ctx.Posada.Add(new Posada()
            {
                ID = item.ID,
                Ime = item.Ime,
                Kapacitet = item.Kapacitet,
                Kormilar = kormilar,
                Kapetan = kapetan,
                Brod = brod
            });
            ctx.SaveChanges();
        }

        public Common.Models.Posada Get(Guid idPosade)
        {
            var posada = ctx.Posada.AsNoTracking().FirstOrDefault((item) => item.ID == idPosade);
            return new Common.Models.Posada(posada.ID, posada.Ime, posada.Kapacitet.Value);
        }

        public IEnumerable<Common.Models.Posada> GetAll()
        {
            var ret = new List<Common.Models.Posada>();
            ctx.Posada.AsNoTracking().ToList().ForEach((item) =>
            {
                ret.Add(new Common.Models.Posada(item.ID, item.Ime, item.Kapacitet.Value));
            });
            return ret;
        }

        public void Update(Common.Models.Posada item)
        {
            var brod = ctx.Posada.FirstOrDefault((b) => b.ID == item.ID);
            ctx.Entry(brod).CurrentValues.SetValues(item);
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
