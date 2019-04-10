using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Final.Models.ViewModel
{
    public class F_Images_Vm
    {
        public Image Image { get; set; }
        public IEnumerable<SelectListItem> Furnitures { get; set; }
    }
}