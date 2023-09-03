using System;
using System.Collections.Generic;

namespace bookapi.Models
{
    public partial class Booklist
    {
        public int Bookid { get; set; }
        public string? Booktitle { get; set; }
        public string? Bookdescription { get; set; }
        public int? Bookprice { get; set; }
    }
}
