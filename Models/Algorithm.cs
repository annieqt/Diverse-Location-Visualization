using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test1.Models
{
    public class Algorithm
    {
        public int algorithmId { get; set; }
        public string name {get; set;}
        public string dir { get; set; }
        public virtual ICollection<Dataset> datas { get; set; }
    }
}