namespace QX_Frame.Data.Entities.QX_Frame
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class db_qx_frame : DbContext
    {
        public db_qx_frame()
            : base("name=db_qx_frame")
        {
        }

        public virtual DbSet<example> tb_token { get; set; }
        public virtual DbSet<tb_userAccount> tb_userAccount { get; set; }
        public virtual DbSet<tb_userFunction> tb_userFunction { get; set; }
        public virtual DbSet<tb_userFunctionAttribute> tb_userFunctionAttribute { get; set; }
        public virtual DbSet<tb_userInfo> tb_userInfo { get; set; }
        public virtual DbSet<tb_userPasswordProtectionQuestion> tb_userPasswordProtectionQuestion { get; set; }
        public virtual DbSet<tb_userRole> tb_userRole { get; set; }
        public virtual DbSet<tb_userRoleAttribute> tb_userRoleAttribute { get; set; }
        public virtual DbSet<tb_userStatus> tb_userStatus { get; set; }
        public virtual DbSet<tb_userStatusAttribute> tb_userStatusAttribute { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_userFunctionAttribute>()
                .HasMany(e => e.tb_userFunction)
                .WithRequired(e => e.tb_userFunctionAttribute)
                .HasForeignKey(e => e.functionRoute)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_userRoleAttribute>()
                .HasMany(e => e.tb_userRole)
                .WithRequired(e => e.tb_userRoleAttribute)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_userStatusAttribute>()
                .HasMany(e => e.tb_userStatus)
                .WithRequired(e => e.tb_userStatusAttribute)
                .WillCascadeOnDelete(false);
        }
    }
}
