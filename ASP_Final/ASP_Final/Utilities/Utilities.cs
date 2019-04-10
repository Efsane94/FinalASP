﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ASP_Final.Utilities
{
    public class Utilities
    {
        public static void RemoveImage(string image, string root)
        {
            string path = Path.Combine(HttpContext.Current.Server.MapPath(root), image);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}