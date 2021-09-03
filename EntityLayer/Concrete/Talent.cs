using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Talent
    {
        [Key]
        public int TalentId { get; set; }
        [StringLength(25)]
        public string TalentName { get; set; }

        public int TalentLevel { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
