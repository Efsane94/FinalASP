using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Final.Models.ViewModel
{
    public class CF_VM
    {
        public Furniture Furniture { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}