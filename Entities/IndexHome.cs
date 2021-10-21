using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class IndexHome : BaseEntity
    {
        [Required]
        public string Header { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string WebArea { get; set; }
        public string Photo { get; set; }
    }
}
