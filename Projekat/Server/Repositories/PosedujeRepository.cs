using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Server.Repositories
{
    internal class PosedujeRepository
    {
        private readonly Projekat_Entities ctx;

        public PosedujeRepository(Projekat_Entities context)
        {
            ctx = context;
        }

        public Brodska_Linija GetLinija(Guid idBrod) => ctx.Poseduje.Include((p) => p.Brodogradiliste).FirstOrDefault((p) => p.Brod.IDBroda == idBrod)?.Brodska_Linija;

        public IEnumerable<Brod> GetBrodAll(Guid brLinije) => ctx.Poseduje.Include((p) => p.Brodogradiliste).Where((poseduje) => poseduje.Brodska_Linija.BrLin == brLinije).Select((s) => s.Brod).AsEnumerable();

        public void Add(Brod brod, Brodska_Linija linija)
        {
            if (ctx.Poseduje.Any((item) => item.Brod.IDBroda == brod.IDBroda && item.Brodska_Linija.BrLin == linija.BrLin))
            {
                return;
            }
            var poseduje = ctx.Poseduje.FirstOrDefault((item) => item.Brod.IDBroda == brod.IDBroda);
            if (poseduje != null)
            {
                ctx.Poseduje.Remove(poseduje);
                ctx.SaveChanges();
            }

            ctx.Poseduje.Add(new Poseduje() { Brod = brod, Brodska_Linija = linija });
            ctx.SaveChanges();
        }
    }
}
