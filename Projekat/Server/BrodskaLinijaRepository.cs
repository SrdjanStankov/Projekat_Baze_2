using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    public class BrodskaLinijaRepository
    {
        private readonly ModelContext ctx;

        public BrodskaLinijaRepository(ModelContext context)
        {
            ctx = context;
        }

        public bool Add(Common.Models.BrodskaLinija item)
        {
            if (ctx.Brodska_Linija.FirstOrDefault((b) => item.BrojLinije == b.BrLin) != null)
            {
                return false;
            }

            ctx.Brodska_Linija.Add(new Brodska_Linija()
            {
                BrLin = item.BrojLinije,
                Krajnja_tacka = item.Krajnja_tacka,
                Polazna_tacka = item.Polazna_tacka,
                Naziv = item.Naziv,
                Tip = item.Tip
            });
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public Common.Models.BrodskaLinija Get(Guid brojLinije)
        {
            var linija = ctx.Brodska_Linija.AsNoTracking().FirstOrDefault((item) => item.BrLin == brojLinije);
            return new Common.Models.BrodskaLinija(linija.BrLin, linija.Naziv, linija.Tip, linija.Polazna_tacka, linija.Krajnja_tacka);
        }

        public IEnumerable<Common.Models.BrodskaLinija> GetAll()
        {
            var ret = new List<Common.Models.BrodskaLinija>();
            ctx.Brodska_Linija.AsNoTracking().ToList().ForEach((item) =>
            {
                ret.Add(new Common.Models.BrodskaLinija(item.BrLin, item.Naziv, item.Tip, item.Polazna_tacka, item.Krajnja_tacka));
            });
            return ret;
        }

        public void Update(Common.Models.BrodskaLinija item)
        {
            var linija = ctx.Brodska_Linija.FirstOrDefault((b) => b.BrLin == item.BrojLinije);
            ctx.Entry(linija).CurrentValues.SetValues(item);
            ctx.SaveChanges();
        }

        public void Remove(Guid brojLinije)
        {
            ctx.Brodska_Linija.Remove(ctx.Brodska_Linija.FirstOrDefault((item) => item.BrLin == brojLinije));
            ctx.SaveChanges();
        }

        ~BrodskaLinijaRepository()
        {
            ctx.Dispose();
        }
    }
}
