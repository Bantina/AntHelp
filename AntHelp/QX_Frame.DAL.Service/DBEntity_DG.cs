namespace QX_Frame.DAL.Service
{
    using System.Data.Entity;
    using QX_Frame.Model;

    public partial class DBEntity_DG : DbContext
    {
        public DBEntity_DG()
            : base("name=DBEntity_DG")
        {
        }

        public virtual DbSet<tb_Class> tb_Class { get; set; }
        public virtual DbSet<tb_User> tb_User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_Class>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<tb_Class>()
                .HasMany(e => e.tb_User)
                .WithRequired(e => e.tb_Class)
                .HasForeignKey(e => e.ClassId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_User>()
                .Property(e => e.Name)
                .IsFixedLength();
        }
    }
}
