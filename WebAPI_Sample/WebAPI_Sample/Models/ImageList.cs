using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Sample.Models
{
    public class ImageList
    {
        public List<Image> Images { set; get; }

        public ImageList()
        {
            Images = new List<Image>();
        }
    }
}