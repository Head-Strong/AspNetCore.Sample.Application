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

        public virtual DbSet<Customer> Customer { get; set; }

        public virtual DbSet<Address> Address { get; set; }
    }
}
