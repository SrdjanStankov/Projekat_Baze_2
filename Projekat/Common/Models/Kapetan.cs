using System;

namespace Common.Models
{
    public class Kapetan
    {
        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pol { get; set; }
        public DateTime GodinaRodjenja { get; set; }
        public Brod Brod { get; set; }
        public Posada Posada { get; set; }
    }
}
