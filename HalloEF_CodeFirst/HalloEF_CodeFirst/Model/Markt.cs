using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloEF_CodeFirst.Model
{
    public class Markt
    {
        public long Id { get; set; }
        public string Ort { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
        public ICollection<Stand> Staende { get; set; } = new HashSet<Stand>();
    }
}
