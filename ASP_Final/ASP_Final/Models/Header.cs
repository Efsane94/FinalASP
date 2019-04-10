using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP_Final.Models
{
    public class Header
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(400)]
        public string Content { get; set; }

        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }
}