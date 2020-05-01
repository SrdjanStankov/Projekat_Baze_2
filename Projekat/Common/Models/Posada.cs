using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class Posada
    {
        public Guid ID { get; set; }
        public string Ime { get; set; }
        public int Kapacitet { get; set; }
        public Brod Brod { get; set; }
        public Kapetan Kapetan { get; set; }
        public Kormilar Kormilar { get; set; }
        public ICollection<Mornar> Mornari { get; set; } = new HashSet<Mornar>();
    }
}
