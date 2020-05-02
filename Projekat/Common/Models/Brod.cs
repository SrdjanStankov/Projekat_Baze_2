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
            GodinaGradnje = godinaGradnje;
            MaxBrzina = maxBrzina;
            Duzina = duzina;
            Sirina = sirina;
        }

        public Guid ID { get; set; }
        public string Ime { get; set; }
        public DateTime GodinaGradnje { get; set; }
        public int MaxBrzina { get; set; }
        public int Duzina { get; set; }
        public int Sirina { get; set; }
    }
}
