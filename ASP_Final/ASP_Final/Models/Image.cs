using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP_Final.Models
{
    public class Image
    {
        public int Id { get; set; }

        
        [StringLength(300)]
        public string Name { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }

        public int FurnitureId { get; set; }

        public virtual Furniture Furniture { get; set; }
    }
}