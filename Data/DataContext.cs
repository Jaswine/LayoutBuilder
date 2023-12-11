using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LayoutBuilder.Data
{
    public class DataContext : DbContext
    {
        // public DbSet<Project> Projects { get; set; }
        // public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects => Set<Project>();
    }
}