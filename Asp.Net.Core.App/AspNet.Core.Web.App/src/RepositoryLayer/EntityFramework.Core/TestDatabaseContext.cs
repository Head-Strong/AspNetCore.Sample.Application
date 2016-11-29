using EntityFramework.Core.Models;
using Microsoft.EntityFrameworkCore;
using Orm.Service.Interface;

namespace EntityFramework.Core
{
    public partial class TestDatabaseContext : DbContext, IOrmservice
    {
        public TestDatabaseContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    //modelBuilder.Entity<Customer>()
        //    //    .HasMany(x => x.Address);
        //}

        public virtual DbSet<Customer> Customer { get; set; }

        public virtual DbSet<Address> Address { get; set; }
    }
}
