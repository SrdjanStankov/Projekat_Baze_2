using System;

namespace Common.Models
{
    public class Kapetan
    {
        public Kapetan()
        {
        }

        public Kapetan(string jMBG, string ime, string prezime, string pol, DateTime godinaRodjenja)
        {
            JMBG = jMBG;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
            GodRodj = godinaRodjenja;
        }

        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pol { get; set; }
        public DateTime GodRodj { get; set; }
        public Brod Brod { get; set; }
        public BrodskaLinija BrodskaLinija { get; set; }
    }
}
