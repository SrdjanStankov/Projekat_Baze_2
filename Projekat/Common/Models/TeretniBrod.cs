using System.Collections.Generic;

namespace Common.Models
{
    public class TeretniBrod : Brod
    {
        public int KapacitetTereta { get; set; }
        public string StatusUtovara { get; set; }
        public ICollection<Mornar> Mornari { get; set; } = new HashSet<Mornar>();
    }
}
