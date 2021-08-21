using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        
        [Key]
        public int UserId { get; set; }
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(25)]
        public string Surname { get; set; }
        [StringLength(50)]
        public string School { get; set; }
        [StringLength(25)]
        public string Section { get; set; }
        //[StringLength(25)]
        //public string SkillName { get; set; }
        [StringLength(500)]
        public string ImagePath { get; set; }
        //public ICollection<Talent> Talents { get; set; }
    }
}
