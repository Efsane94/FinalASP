using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Final.Models.ViewModel
{
    public class FurnitureImage_VM
    {
        public Header Header { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Furniture> Furnitures { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public AboutFeatured AboutFeatured { get; set; }
        
    }
}