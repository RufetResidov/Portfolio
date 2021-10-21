using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Projects : BaseEntity
    {
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string Photo { get; set; }
        public string PhotoTitle { get; set; }
    }
}
