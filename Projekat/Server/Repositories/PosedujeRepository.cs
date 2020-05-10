using System;
using System.Data.Entity;
using System.Linq;

namespace Server.Repositories
{
    internal class PosedujeRepository
    {
        private readonly ModelContext ctx;

        public PosedujeRepository(ModelContext context)
        {
            ctx = context;
        }

        public Brodska_Linija GetLinija(Guid idBrod) => ctx.Poseduje.Include((p) => p.Brodogradiliste).FirstOrDefault((p) => p.Brod.IDBroda == idBrod)?.Brodska_Linija;

        public Brod GetBrod(Guid brLinije) => ctx.Poseduje.Include((p) => p.Brodogradiliste).FirstOrDefault((p) => p.Brodska_Linija.BrLin == brLinije)?.Brod;
    }
}
