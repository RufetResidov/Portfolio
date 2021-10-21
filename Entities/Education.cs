using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Education : BaseEntity
    {
        public string Name { get; set; }
        public string EducationName { get; set; }
        public string Session { get; set; }
    }
}
