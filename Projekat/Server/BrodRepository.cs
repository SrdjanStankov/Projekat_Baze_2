using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Server
{
    public class BrodRepository
    {
        private ModelContext context;

        public BrodRepository(ModelContext context)
        {
            this.context = context;
        }

        public void Add(Common.Models.Brod item)
        {
            var brod = new Brod()
            {
                Duzina = item.Duzina,
                IDBroda = item.ID,
                Ime = item.Ime,
                GodGrad = item.GodinaGradnje,
                MaxBrzina = item.MaxBrzina,
                Sirina = item.Sirina
            };
            context.Brod.Add(brod);
            context.SaveChanges();
        }

        public IEnumerable<Brod> Get(Guid id)
        {
            return context.Brod.Where((item) => item.IDBroda == id).AsNoTracking().AsEnumerable();
        }

        public void Update(Brod item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        ~BrodRepository()
        {
            context.Dispose();
        }
    }
}
