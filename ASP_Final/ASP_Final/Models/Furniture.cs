using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_Final.Models
{
    public class Furniture
    {
        public Furniture()
        {
            Images = new HashSet<Image>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Price { get; set; }

        public int  CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}