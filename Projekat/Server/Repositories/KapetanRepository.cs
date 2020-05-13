using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Server.Repositories
{
    public class KapetanRepository
    {
        private readonly ModelContext ctx;

        public KapetanRepository(ModelContext context)
        {
            ctx = context;
        }

        public bool Add(Common.Models.Kapetan item, Guid brLinije, Guid idBroda)
        {
            if (ctx.Kapetan.FirstOrDefault((b) => item.JMBG == b.JMBG) != null)
            {
                return false;
            }

            var linija = ctx.Brodska_Linija.FirstOrDefault((lin) => lin.BrLin == brLinije);
            if (linija is null)
            {
                return false;
            }

            var brod = ctx.Brod.FirstOrDefault((b) => b.IDBroda == idBroda);
            if (brod is null)
            {
                return false;
            }

            ctx.Kapetan.Add(new Kapetan()
            {
                JMBG = item.JMBG,
                Ime = item.Ime,
                Pol = item.Pol,
                Prezime = item.Prezime,
                GodRodj = item.GodRodj,
                Brodska_Linija = linija,
                Brod = brod
            });
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public Common.Models.Kapetan Get(string jmbg)
        {
            var kapetan = ctx.Kapetan.AsNoTracking().FirstOrDefault((item) => item.JMBG == jmbg);
            return new Common.Models.Kapetan(kapetan.JMBG, kapetan.Ime, kapetan.Prezime, kapetan.Pol, kapetan.GodRodj.Value);
        }

        public IEnumerable<Common.Models.Kapetan> GetAll()
        {
            var ret = new List<Common.Models.Kapetan>();
            ctx.Kapetan.AsNoTracking().Include((k)=> k.Brod).Include((k)=> k.Brodska_Linija).ToList().ForEach((kapetan) =>
            {
                var CKapetan = new Common.Models.Kapetan(kapetan.JMBG, kapetan.Ime, kapetan.Prezime, kapetan.Pol, kapetan.GodRodj.Value);
                CKapetan.Brod = new Common.Models.Brod(kapetan.Brod.IDBroda, kapetan.Brod.Ime, kapetan.Brod.GodGrad, kapetan.Brod.MaxBrzina.Value, kapetan.Brod.Duzina.Value, kapetan.Brod.Sirina.Value);
                CKapetan.BrodskaLinija = new Common.Models.BrodskaLinija(kapetan.Brodska_Linija.BrLin, kapetan.Brodska_Linija.Naziv, kapetan.Brodska_Linija.Tip, kapetan.Brodska_Linija.Polazna_tacka, kapetan.Brodska_Linija.Krajnja_tacka);
                ret.Add(CKapetan);
            });
            return ret;
        }

        public void Update(Common.Models.Kapetan item)
        {
            var kapetan = ctx.Kapetan.FirstOrDefault((b) => b.JMBG == item.JMBG);
            ctx.Entry(kapetan).CurrentValues.SetValues(item);
            ctx.SaveChanges();
        }

        public void Remove(string jmbg)
        {
            ctx.Kapetan.Remove(ctx.Kapetan.FirstOrDefault((item) => item.JMBG == jmbg));
            ctx.SaveChanges();
        }

        ~KapetanRepository()
        {
            ctx.Dispose();
        }
    }
}
