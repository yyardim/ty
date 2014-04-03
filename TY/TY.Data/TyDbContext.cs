using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TY.Data.Configurations;
using TY.Model;

namespace TY.Data
{
    public class TyDbContext: DbContext
    {
        public TyDbContext() : base(nameOrConnectionString: "ty") { }
        static TyDbContext()
        {
            // EF 6.0.1 throws an exception, unless we first probe the provider types.
            var type1 = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            Database.SetInitializer(new TyDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Disable proxy creation and lazy loading; not wanted in this service context.
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            modelBuilder.Configurations.Add(new CategoryConfiguration());
            //modelBuilder.Configurations.Add(new TyConfiguration());
            //modelBuilder.Configurations.Add(new PersonConfiguration());
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
