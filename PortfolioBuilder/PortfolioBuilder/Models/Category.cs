using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioBuilder.Models
{
    public class Category
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public List<Subcategory> Subcategories { get; set; }
    }
}
