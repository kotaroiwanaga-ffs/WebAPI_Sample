using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Sample.Models
{
    public class Image
    {
        public int Id { get; set; }
        public List<string> Tags { set; get; }
        public string Path { get; set; }
    }
}