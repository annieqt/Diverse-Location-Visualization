using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test1.Models
{
    public class Dataset
    {
        public int datasetId { get; set; }
        public string name { get; set; }
        public string dir { get; set; }
        public virtual ICollection<Algorithm> als { get; set; }
    }
}