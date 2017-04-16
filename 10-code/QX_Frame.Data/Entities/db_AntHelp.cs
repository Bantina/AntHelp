namespace QX_Frame.Data.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class db_AntHelp : DbContext
    {
        public db_AntHelp()
            : base("name=db_AntHelp")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<tb_Article> tb_Article { get; set; }
        public virtual DbSet<tb_ArticleCategory> tb_ArticleCategory { get; set; }
        public virtual DbSet<tb_CommentReply> tb_CommentReply { get; set; }
        public virtual DbSet<tb_ComplainStatus> tb_ComplainStatus { get; set; }
        public virtual DbSet<tb_FavorableActivity> tb_FavorableActivity { get; set; }
        public virtual DbSet<tb_MessagePush> tb_MessagePush { get; set; }
        public virtual DbSet<tb_MessagePushCategory> tb_MessagePushCategory { get; set; }
        public virtual DbSet<tb_MessagePushStatus> tb_MessagePushStatus { get; set; }
        public virtual DbSet<tb_Order> tb_Order { get; set; }
        public virtual DbSet<tb_Complain> tb_OrderComplain { get; set; }
        public virtual DbSet<tb_OrderEvaluate> tb_OrderEvaluate { get; set; }
        public virtual DbSet<tb_OrderStatus> tb_OrderStatus { get; set; }
        public virtual DbSet<tb_RelationStatus> tb_RelationStatus { get; set; }
        public virtual DbSet<tb_SelfMessage> tb_SelfMessage { get; set; }
        public virtual DbSet<tb_UserRelation> tb_UserRelation { get; set; }
        public virtual DbSet<tb_Voucher> tb_Voucher { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_ArticleCategory>()
                .HasMany(e => e.tb_Article)
                .WithRequired(e => e.tb_ArticleCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_ComplainStatus>()
                .HasMany(e => e.tb_OrderComplain)
                .WithRequired(e => e.tb_ComplainStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_MessagePushCategory>()
                .HasMany(e => e.tb_MessagePush)
                .WithRequired(e => e.tb_MessagePushCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_MessagePushStatus>()
                .HasMany(e => e.tb_MessagePush)
                .WithRequired(e => e.tb_MessagePushStatus)
                .HasForeignKey(e => e.messagePushStatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_OrderEvaluate>()
                .HasMany(e => e.tb_Order)
                .WithRequired(e => e.tb_OrderEvaluate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_OrderStatus>()
                .HasMany(e => e.tb_Order)
                .WithRequired(e => e.tb_OrderStatus)
                .WillCascadeOnDelete(false);

        }
    }
}
