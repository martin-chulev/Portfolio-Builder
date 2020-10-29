using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioBuilder.Models
{
    public class Resource
    {
        [Key]
        public string Id { get; set; }

        public string Title { get; set; }

        public List<string> URLs { get; set; }
    }
}
