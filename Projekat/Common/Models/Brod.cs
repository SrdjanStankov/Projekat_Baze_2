using System;

namespace Common.Models
{
    public class Brod
    {
        public Brod()
        {
        }

        public Brod(Guid iD, string ime, DateTime godinaGradnje, int maxBrzina, int duzina, int sirina)
        {
            ID = iD;
            Ime = ime;
            GodGrad = godinaGradnje;
            MaxBrzina = maxBrzina;
            Duzina = duzina;
            Sirina = sirina;
        }

        public Guid ID { get; set; }
        public string Ime { get; set; }
        public DateTime GodGrad { get; set; }
        public int MaxBrzina { get; set; }
        public int Duzina { get; set; }
        public int Sirina { get; set; }
        public BrodskaLinija BrodskaLinija { get; set; }

        public override string ToString() => $"{Ime}, {GodGrad.ToShortDateString()}";
    }
}
