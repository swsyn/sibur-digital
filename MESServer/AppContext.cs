using MESModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MESServer
{
    public class AppContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeCategory> EmployeeCategories { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAvailability> ProductAvailabilities { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public AppContext() : base("DbConnection")
        {

        }
    }
}