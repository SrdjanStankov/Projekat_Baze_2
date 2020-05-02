﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    public class KapetanRepository
    {
        private readonly ModelContext ctx;

        public KapetanRepository(ModelContext context)
        {
            ctx = context;
        }

        public void Add(Common.Models.Kapetan item, Guid brLinije, Guid idBroda)
        {
            if (ctx.Kapetan.FirstOrDefault((b) => item.JMBG == b.JMBG) != null)
            {
                return;
            }

            var linija = ctx.Brodska_Linija.FirstOrDefault((lin) => lin.BrLin == brLinije);
            if (linija is null)
            {
                return;
            }

            var brod = ctx.Brod.FirstOrDefault((b) => b.IDBroda == idBroda);
            if (brod is null)
            {
                return;
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
            ctx.SaveChanges();
        }

        public Common.Models.Kapetan Get(string jmbg)
        {
            var kapetan = ctx.Kapetan.AsNoTracking().FirstOrDefault((item) => item.JMBG == jmbg);
            return new Common.Models.Kapetan(kapetan.JMBG, kapetan.Ime, kapetan.Prezime, kapetan.Pol, kapetan.GodRodj.Value);
        }

        public IEnumerable<Common.Models.Kapetan> GetAll()
        {
            var ret = new List<Common.Models.Kapetan>();
            ctx.Kapetan.AsNoTracking().ToList().ForEach((item) =>
            {
                ret.Add(new Common.Models.Kapetan(item.JMBG, item.Ime, item.Prezime, item.Pol, item.GodRodj.Value));
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
