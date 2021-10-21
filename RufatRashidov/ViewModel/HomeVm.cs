using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RufatRashidov.ViewModel
{
    public class HomeVm
    {
        public IndexHome Home { get; set; }
        public About About { get; set; }
        public List<Services> Services { get; set; }
        public List<CodingSkill> CodingSkill { get; set; }
        public List<Skills> ToolSkill { get; set; }
        public List<Education> Educations { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Projects> Projects { get; set; }
        public List<Category> Categories { get; set; }
        public Contact Contact { get; set; }
    }
}
