using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloEF_CodeFirst.Model
{
    [Table("Market")]
    public class Markt
    {
        public long Id { get; set; }
       
        [Column("City")]
        [MaxLength(76)]
        public string Ort { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
        public ICollection<Stand> Staende { get; set; } = new HashSet<Stand>();
    }
}
