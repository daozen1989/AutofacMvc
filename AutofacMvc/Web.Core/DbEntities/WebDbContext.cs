namespace Web.Core.DbEntities
{
    using System.Data.Entity;
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

        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Role>();
            modelBuilder.Entity<Team>();
            modelBuilder.Entity<Log>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
