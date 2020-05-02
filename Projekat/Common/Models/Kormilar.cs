namespace Common.Models
{
    public class Kormilar
    {
        public Kormilar()
        {
        }

        public Kormilar(string jMBG, string ime, string prezime, string pol)
        {
            JMBG = jMBG;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
        }

        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pol { get; set; }
    }
}
