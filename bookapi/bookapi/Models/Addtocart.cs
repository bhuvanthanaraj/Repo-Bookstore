using System;
using System.Collections.Generic;

namespace bookapi.Models
{
    public partial class Addtocart
    {
        public int? Bookid { get; set; }
        public string? Booktitle { get; set; }
        public int? Bookprice { get; set; }
    }
}
