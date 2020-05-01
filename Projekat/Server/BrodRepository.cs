using System;
using System.Collections.Generic;

namespace Server
{
    public class BrodRepository
    {
        private ModelContext ctx;

        public BrodRepository(ModelContext context)
        {
            ctx = context;
        }

        public void Add(Common.Models.Brod item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Common.Models.Brod> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Common.Models.Brod item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        ~BrodRepository()
        {
            ctx.Dispose();
        }
    }
}
