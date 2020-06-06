using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Server.Repositories
{
    public class BrodRepository
    {
        private readonly Projekat_Entities ctx;
        private PosedujeRepository posedujeRepo;

        public BrodRepository(Projekat_Entities context)
        {
            ctx = context;
            posedujeRepo = new PosedujeRepository(context);
        }

        public bool Add(Common.Models.Brod item, Guid idBrodogradilista)
        {
            if (ctx.Brod.FirstOrDefault((b) => item.ID == b.IDBroda) != null)
            {
                return false;
            }

            var brodo = ctx.Brodogradiliste.FirstOrDefault((b) => b.IDBrodog == idBrodogradilista);
            if (brodo is null)
            {
                return false;
            }

            ctx.Brod.Add(new Brod()
            {
                IDBroda = item.ID,
                Ime = item.Ime,
                GodGrad = item.GodGrad,
                MaxBrzina = item.MaxBrzina,
                Duzina = item.Duzina,
                Sirina = item.Sirina,
                Brodogradiliste = brodo
            });
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public Common.Models.Brod Get(Guid id)
        {
            var brod = ctx.Brod.AsNoTracking().FirstOrDefault((item) => item.IDBroda == id);
            var CBrod = new Common.Models.Brod(brod.IDBroda, brod.Ime, brod.GodGrad, brod.MaxBrzina.Value, brod.Duzina.Value, brod.Sirina.Value);

            var linija = posedujeRepo.GetLinija(brod.IDBroda);
            if (linija != null)
            {
                CBrod.BrodskaLinija = new Common.Models.BrodskaLinija(linija.BrLin, linija.Naziv, linija.Tip, linija.Polazna_tacka, linija.Krajnja_tacka);
            }
            return CBrod;
        }

        public IEnumerable<Common.Models.Brod> GetAll()
        {
            var ret = new List<Common.Models.Brod>();
            ctx.Brod.Include((bl) => bl.Poseduje).AsNoTracking().ToList().ForEach((item) =>
            {
                if (ctx.Teretni_Brod.Find(item.IDBroda) is null && ctx.Kruzer.Find(item.IDBroda) is null && ctx.Tanker.Find(item.IDBroda) is null)
                {
                    var brod = new Common.Models.Brod(item.IDBroda, item.Ime, item.GodGrad, item.MaxBrzina.Value, item.Duzina.Value, item.Sirina.Value);
                    var linija = posedujeRepo.GetLinija(brod.ID);
                    if (linija != null)
                    {
                        brod.BrodskaLinija = new Common.Models.BrodskaLinija(linija.BrLin, linija.Naziv, linija.Tip, linija.Polazna_tacka, linija.Krajnja_tacka);
                    }
                    ret.Add(brod); 
                }
            });
            return ret;
        }

        public void Update(Common.Models.Brod item)
        {
            var brod = ctx.Brod.FirstOrDefault((b) => b.IDBroda == item.ID);
            ctx.Entry(brod).CurrentValues.SetValues(item);
            ctx.SaveChanges();
        }

        public bool Remove(Guid id)
        {
            try
            {
                ctx.Brod.Remove(ctx.Brod.FirstOrDefault((item) => item.IDBroda == id));
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddLinija(Guid brodId, Guid brojLinije)
        {
            var brod = ctx.Brod.FirstOrDefault((b) => b.IDBroda == brodId);
            var linija = ctx.Brodska_Linija.FirstOrDefault((l) => l.BrLin == brojLinije);
            posedujeRepo.Add(brod, linija);
        }

        ~BrodRepository()
        {
            ctx.Dispose();
        }
    }
}
