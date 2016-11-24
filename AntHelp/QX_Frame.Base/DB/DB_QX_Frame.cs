namespace QX_Frame.Base.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Entities;

    public partial class DB_QX_Frame : DbContext
    {
        public DB_QX_Frame()
            : base("name=DB_QX_Frame")
        {
        }

        public virtual DbSet<tb_token> tb_token { get; set; }
        public virtual DbSet<tb_userAccount> tb_userAccount { get; set; }
        public virtual DbSet<tb_userInfo> tb_userInfo { get; set; }
        public virtual DbSet<tb_userLimit> tb_userLimit { get; set; }
        public virtual DbSet<tb_userLimitName> tb_userLimitName { get; set; }
        public virtual DbSet<tb_userStatus> tb_userStatus { get; set; }
        public virtual DbSet<tb_userStatusName> tb_userStatusName { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_userLimitName>()
                .HasMany(e => e.tb_userLimit)
                .WithRequired(e => e.tb_userLimitName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_userStatusName>()
                .HasMany(e => e.tb_userStatus)
                .WithRequired(e => e.tb_userStatusName)
                .WillCascadeOnDelete(false);
        }
    }
}
