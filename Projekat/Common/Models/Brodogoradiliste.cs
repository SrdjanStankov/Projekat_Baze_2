using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class Brodogoradiliste
    {
        public Guid ID { get; set; }
        public string Naziv { get; set; }
        public string Lokacija { get; set; }
        public int BrojNapravljenihBrodova { get; set; }
        public int BrojPristanista { get; set; }
        public bool PosedujeSuviDok { get; set; }
        public ICollection<Brod> Brod { get; set; } = new HashSet<Brod>();
    }
}
