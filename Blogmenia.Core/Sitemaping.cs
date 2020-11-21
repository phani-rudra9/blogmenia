using System;
using System.Collections.Generic;
using System.Text;

namespace Blogmenia.Core
{
    public class Sitemaping
    {

        public int Id { get; set; }
        public string URl { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Priority { get; set; }

        public int IsActive { get; set; }
    }
}
