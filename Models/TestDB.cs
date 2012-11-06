using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Test1.Models
{
    public class TestDB :DbContext
    {
        public DbSet<Algorithm> als { get; set; }
        public DbSet<Dataset> datas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Algorithm>()
                .HasMany<Dataset>(a => a.datas)
                .WithMany(p => p.als)
                .Map(
                     m =>
                     {
                         m.MapLeftKey("datasetId");
                         m.MapRightKey("algorithmId");
                         m.ToTable("DatasetAlgorithm");
                     }
                );
        }
    }
}