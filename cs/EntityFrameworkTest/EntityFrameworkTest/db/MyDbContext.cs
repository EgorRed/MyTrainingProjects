using System;
using System.Data.Entity;

namespace EntityFrameworkTest
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("DbConnectionString")
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
