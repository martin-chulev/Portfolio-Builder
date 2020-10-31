using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioBuilder.Models
{
    public class Subskill
    {
        [Key]
        public string Id { get; set; }

        public string ShortName { get; set; }

        public string LongName { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Documentation, Guides, etc.
        /// </summary>
        public List<Resource> Resources { get; set; }

        public List<ProjectSubskill> RelatedProjects { get; set; }
    }
}
