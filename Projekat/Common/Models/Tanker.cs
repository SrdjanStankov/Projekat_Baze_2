using System;

namespace Common.Models
{
    public class Tanker : Brod
    {
        public Tanker()
        {
        }

        public Tanker(Guid iD, string ime, DateTime godinaGradnje, int maxBrzina, int duzina, int sirina, int nosivost, string tipTereta) : base(iD, ime, godinaGradnje, maxBrzina, duzina, sirina)
        {
            Nosivost = nosivost;
            TipTeret = tipTereta;
        }

        public int Nosivost { get; set; }
        public string TipTeret { get; set; }
    }
}
