using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class Brodska_Linija
    {
        public Guid BrojLinije { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string PolaznaTacka { get; set; }
        public string KrajnjaTacka { get; set; }
        public ICollection<Kapetan> Kapetan { get; set; } = new HashSet<Kapetan>();
    }
}
