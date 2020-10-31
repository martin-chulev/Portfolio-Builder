using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioBuilder.Models
{
    public class Project
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ProjectSubskill> InvolvedSkills { get; set; }

        public List<Resource> References { get; set; }

        /// <summary>
        /// {latitude};{longitude}
        /// </summary>
        public List<string> Geolocations { get; set; }

        // TODO: Gallery (list of media - images, sound files, etc.)
    }
}
