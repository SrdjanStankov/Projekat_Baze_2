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
            BrojNapravljenihBrodova = brojNapravljenihBrodova;
            BrojPristanista = brojPristanista;
            PosedujeSuviDok = posedujeSuviDok;
        }

        public Guid ID { get; set; }
        public string Naziv { get; set; }
        public string Lokacija { get; set; }
        public int BrojNapravljenihBrodova { get; set; }
        public int BrojPristanista { get; set; }
        public bool PosedujeSuviDok { get; set; }
        public ICollection<Brod> Brod { get; set; } = new HashSet<Brod>();
    }
}
