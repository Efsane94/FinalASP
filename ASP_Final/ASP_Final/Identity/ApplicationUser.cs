                                                using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP_Final.Identity
{
    public class ApplicationUser:IdentityUser
    {
        [Required,MinLength(3)]
        [StringLength(50)]
        public string Name { get; set; }

        [Required, MinLength(3)]
        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }
}