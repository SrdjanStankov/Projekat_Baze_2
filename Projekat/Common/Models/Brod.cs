using System;

namespace Common.Models
{
    public class Brod
    {
        public Guid ID { get; set; }
        public string Ime { get; set; }
        public DateTime GodinaGradnje { get; set; }
        public int MaxBrzina { get; set; }
        public int Duzina { get; set; }
        public int Sirina { get; set; }
        public Brodogoradiliste Brodogoradiliste { get; set; }
        public Kapetan Kapetan { get; set; }
        public Posada Posada { get; set; }
    }
}
