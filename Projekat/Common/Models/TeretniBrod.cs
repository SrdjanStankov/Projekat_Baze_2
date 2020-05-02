using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class TeretniBrod : Brod
    {
        public TeretniBrod()
        {
        }

        public TeretniBrod(Guid iD, string ime, DateTime godinaGradnje, int maxBrzina, int duzina, int sirina, int kapacitetTereta, string statusUtovara) : base(iD, ime, godinaGradnje, maxBrzina, duzina, sirina)
        {
            KapacTeret = kapacitetTereta;
            StatUtov = statusUtovara;
        }

        public int KapacTeret { get; set; }
        public string StatUtov { get; set; }
        public ICollection<Mornar> Mornari { get; set; } = new HashSet<Mornar>();
    }
}
