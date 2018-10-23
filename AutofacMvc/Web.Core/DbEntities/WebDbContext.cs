namespace Web.Core.DbEntities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Web.Interfaces.Interfaces;

    public partial class WebDbContext : DbContext, IDbContext
    {
        public WebDbContext(string connStr)
            : base(connStr)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public WebDbContext()
            : base("name=WebDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();

        }

        public virtual DbSet<Audio> Audios { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<BookAudio> BookAudios { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<BookDomain> BookDomains { get; set; }
        public virtual DbSet<BookGroup> BookGroups { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookVideo> BookVideos { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Audio>();
            modelBuilder.Entity<Author>();
            modelBuilder.Entity<BookAudio>();
            modelBuilder.Entity<BookCategory>();
            modelBuilder.Entity<BookDomain>();
            modelBuilder.Entity<BookGroup>();
            modelBuilder.Entity<Book>();
            modelBuilder.Entity<BookVideo>();
            modelBuilder.Entity<Video>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
