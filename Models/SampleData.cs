using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Test1.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<TestDB>
    {
        protected override void Seed(TestDB context)
        {            
            var ds = new List<Dataset>
            {
                new Dataset{name = "data1", dir = "C:/"},
                new Dataset{name = "data2", dir = "C:/"},
                new Dataset{name = "data3", dir = "C:/"},
                new Dataset{name = "data4", dir = "C:/"}
            };

            ds.ForEach(d => context.datas.Add(d));

            var als = new List<Algorithm>
           {
               new Algorithm{name = "al1", dir = "C:/", datas = ds},
               new Algorithm{name = "al2", dir = "C:/", datas = ds},
               new Algorithm{name = "al3", dir = "C:/", datas = ds}
           };

            als.ForEach(a => context.als.Add(a));
            context.SaveChanges();
        }
    }
}