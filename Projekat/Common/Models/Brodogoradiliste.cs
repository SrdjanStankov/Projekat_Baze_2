using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class Brodogradiliste
    {
        public Brodogradiliste()
        {
        }

        public Brodogradiliste(Guid iD, string naziv, string lokacija, int brojNapravljenihBrodova, int brojPristanista, bool posedujeSuviDok)
        {
            ID = iD;
            Naziv = naziv;
            Lokacija = lokacija;
            BrNaprBrod = brojNapravljenihBrodova;
            BrPrist = brojPristanista;
            PosedSuvDok = posedujeSuviDok;
        }

        public Guid ID { get; set; }
        public string Naziv { get; set; }
        public string Lokacija { get; set; }
        public int BrNaprBrod { get; set; }
        public int BrPrist { get; set; }
        public bool PosedSuvDok { get; set; }
        public ICollection<Brod> Brod { get; set; } = new HashSet<Brod>();
    }
}
