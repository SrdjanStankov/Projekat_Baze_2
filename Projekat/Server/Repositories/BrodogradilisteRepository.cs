﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Repositories
{
    public class BrodogradilisteRepository
    {
        private readonly Projekat_Entities ctx;

        public BrodogradilisteRepository(Projekat_Entities context)
        {
            ctx = context;
        }

        public bool Add(Common.Models.Brodogradiliste item)
        {
            if (ctx.Brodogradiliste.FirstOrDefault((b) => item.ID == b.IDBrodog) != null)
            {
                return false;
            }

            ctx.Brodogradiliste.Add(new Brodogradiliste()
            {
                IDBrodog = item.ID,
                Naziv = item.Naziv,
                Lokacija = item.Lokacija,
                BrNaprBrod = item.BrNaprBrod,
                BrPrist = item.BrPrist,
                PosedSuvDok = item.PosedSuvDok
            });
            return ctx.SaveChanges() > 0 ? true : false;
        }

        public Common.Models.Brodogradiliste Get(Guid id)
        {
            var brodo = ctx.Brodogradiliste.AsNoTracking().FirstOrDefault((item) => item.IDBrodog == id);
            return new Common.Models.Brodogradiliste(brodo.IDBrodog, brodo.Naziv, brodo.Lokacija, brodo.BrNaprBrod.Value, brodo.BrPrist.Value, brodo.PosedSuvDok.Value);
        }

        public IEnumerable<Common.Models.Brodogradiliste> GetAll()
        {
            var ret = new List<Common.Models.Brodogradiliste>();
            ctx.Brodogradiliste.AsNoTracking().ToList().ForEach((item) =>
            {
                ret.Add(new Common.Models.Brodogradiliste(item.IDBrodog, item.Naziv, item.Lokacija, item.BrNaprBrod.Value, item.BrPrist.Value, item.PosedSuvDok.Value));
            });
            return ret;
        }

        public void Update(Common.Models.Brodogradiliste item)
        {
            var brodo = ctx.Brodogradiliste.FirstOrDefault((b) => b.IDBrodog == item.ID);
            ctx.Entry(brodo).CurrentValues.SetValues(item);
            ctx.SaveChanges();
        }

        public bool Remove(Guid id)
        {
            try
            {
                ctx.Brodogradiliste.Remove(ctx.Brodogradiliste.FirstOrDefault((item) => item.IDBrodog == id));
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        ~BrodogradilisteRepository()
        {
            ctx.Dispose();
        }
    }
}
