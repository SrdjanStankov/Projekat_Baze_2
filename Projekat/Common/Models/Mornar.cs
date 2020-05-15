namespace Common.Models
{
    public class Mornar
    {
        public Mornar()
        {
        }

        public Mornar(string jMBG, string ime, string prezime, string pol, string rank)
        {
            JMBG = jMBG;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
            Rank = rank;
        }

        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pol { get; set; }
        public string Rank { get; set; }
        public Posada Posada { get; set; }
    }
}
