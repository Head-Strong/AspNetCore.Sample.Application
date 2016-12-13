using EntityFramework.Core.Models;
using Microsoft.EntityFrameworkCore;
using Orm.Service.Interface;

namespace EntityFramework.Core
{
    public partial class TestDatabaseContext : DbContext, IOrmservice
    {
        public TestDatabaseContext(DbContextOptions<TestDatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfileRoleLink>().HasKey(x => new
            {
                x.IdProfile,
                x.IdRole
            });
        }

        public virtual DbSet<Customer> Customer { get; set; }

        public virtual DbSet<Address> Address { get; set; }

        public virtual DbSet<Profiles> Profiles { get; set; }

        public virtual DbSet<Roles> Roles { get; set; }

        public virtual DbSet<ProfileRoleLink> ProfileRoleLinks { get; set; }

    }
}
