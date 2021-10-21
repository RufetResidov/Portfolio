using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Experience : BaseEntity
    {
        public string WorkHouse { get; set; }
        public string WorkArea { get; set; }
        public string WorkTime { get; set; }
        public string Title { get; set; }
    }
}
