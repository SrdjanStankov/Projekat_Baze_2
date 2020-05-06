using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class BrodskaLinija
    {
        public BrodskaLinija()
        {
        }

        public BrodskaLinija(Guid brojLinije, string naziv, string tip, string polaznaTacka, string krajnjaTacka)
        {
            BrojLinije = brojLinije;
            Naziv = naziv;
            Tip = tip;
            Polazna_tacka = polaznaTacka;
            Krajnja_tacka = krajnjaTacka;
        }

        public Guid BrojLinije { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string Polazna_tacka { get; set; }
        public string Krajnja_tacka { get; set; }
        public ICollection<Kapetan> Kapetan { get; set; } = new HashSet<Kapetan>();
        public ICollection<Brod> Brodovi { get; set; } = new HashSet<Brod>();

        public override string ToString() => $"{Naziv}, {Polazna_tacka}, {Krajnja_tacka}";
    }
}
