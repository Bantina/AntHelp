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

        public virtual DbSet<tb_Authentication> tb_Authentication { get; set; }
        public virtual DbSet<tb_BloodType> tb_BloodType { get; set; }
        public virtual DbSet<tb_Sex> tb_Sex { get; set; }
        public virtual DbSet<tb_UserAccount> tb_UserAccount { get; set; }
        public virtual DbSet<tb_UserAccountInfo> tb_UserAccountInfo { get; set; }
        public virtual DbSet<tb_UserFunction> tb_UserFunction { get; set; }
        public virtual DbSet<tb_UserPasswordProtectionQuestion> tb_UserPasswordProtectionQuestion { get; set; }
        public virtual DbSet<tb_UserRole> tb_UserRole { get; set; }
        public virtual DbSet<tb_UserRoleAttribute> tb_UserRoleAttribute { get; set; }
        public virtual DbSet<tb_UserStatus> tb_UserStatus { get; set; }
        public virtual DbSet<tb_UserStatusAttribute> tb_UserStatusAttribute { get; set; }
        public virtual DbSet<tb_UserMoney> tb_UserMoney { get; set; }
        public virtual DbSet<tb_UserMoneyBill> tb_UserMoneyBill { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_BloodType>()
                .Property(e => e.bloodTypeName)
                .IsFixedLength();

            modelBuilder.Entity<tb_BloodType>()
                .HasMany(e => e.tb_UserAccountInfo)
                .WithRequired(e => e.tb_BloodType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Sex>()
                .Property(e => e.sexName)
                .IsFixedLength();

            modelBuilder.Entity<tb_Sex>()
                .HasMany(e => e.tb_UserAccountInfo)
                .WithRequired(e => e.tb_Sex)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_UserAccountInfo>()
                .Property(e => e.constellation)
                .IsFixedLength();

            modelBuilder.Entity<tb_UserAccountInfo>()
                .Property(e => e.chineseZodiac)
                .IsFixedLength();

            modelBuilder.Entity<tb_UserRoleAttribute>()
                .HasMany(e => e.tb_UserRole)
                .WithRequired(e => e.tb_UserRoleAttribute)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_UserStatusAttribute>()
                .HasMany(e => e.tb_UserStatus)
                .WithRequired(e => e.tb_UserStatusAttribute)
                .WillCascadeOnDelete(false);
        }
    }
}
