using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioBuilder.Models
{
    public class ProjectSubskill
    {
        public string ProjectId { get; set; }

        public Project Project { get; set; }

        public string SubskillId { get; set; }

        public Subskill Subskill { get; set; }

        public bool IsMain { get; set; }
    }
}
