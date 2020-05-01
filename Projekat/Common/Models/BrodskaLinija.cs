using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class BrodskaLinija
    {
        public Guid BrojLinije { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string PolaznaTacka { get; set; }
        public string KrajnjaTacka { get; set; }
        public ICollection<Kapetan> Kapetan { get; set; } = new HashSet<Kapetan>();
        public ICollection<Brod> Brodovi { get; set; } = new HashSet<Brod>();
    }
}
