using System;

namespace Common.Models
{
    public class Kruzer : Brod
    {
        public Kruzer()
        {
        }

        public Kruzer(Guid iD, string ime, DateTime godinaGradnje, int maxBrzina, int duzina, int sirina, int brojPutnika, int brojOsoblja) : base(iD, ime, godinaGradnje, maxBrzina, duzina, sirina)
        {
            BrPutnika = brojPutnika;
            BrOsoblja = brojOsoblja;
        }

        public int BrPutnika { get; set; }
        public int BrOsoblja { get; set; }
    }
}
