using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EfLocalDbDemo.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users => Set<User>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EfLocalDbTest;Trusted_Connection=True;");
        }
    }
    public class User
    {
    public int Id { get; set; }
    public string Name { get; set; } = "";
    }
}