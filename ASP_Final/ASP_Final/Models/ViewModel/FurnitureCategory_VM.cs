using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Final.Models.ViewModel
{
    public class FurnitureCategory_VM
    {
        public IEnumerable<Furniture> Furnitures { get; set; }
        public CategoryPageHeader CategoryPage { get; set; }
    }
}