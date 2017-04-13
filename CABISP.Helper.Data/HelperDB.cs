namespace CABISP.Helper.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HelperDB : DbContext
    {
        public HelperDB()
            : base("name=HelperDB")
        {
        }

        public virtual DbSet<zf_HelperContent> zf_HelperContent { get; set; }
        public virtual DbSet<zf_HelperType> zf_HelperType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<zf_HelperType>()
                .HasMany(e => e.zf_HelperContent)
                .WithRequired(e => e.zf_HelperType)
                .WillCascadeOnDelete(false);
        }
    }
}
