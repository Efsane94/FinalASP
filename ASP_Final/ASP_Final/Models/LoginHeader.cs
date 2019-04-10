using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP_Final.Models
{
    public class LoginHeader
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength(300)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }
}