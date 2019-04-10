using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_Final.Models
{
    public class Category
    {
        public Category()
        {
            Furnitures = new HashSet<Furniture>(); 
        }
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Furniture> Furnitures { get; set; }
    }
}