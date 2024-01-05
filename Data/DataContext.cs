using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LayoutBuilder.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionProject> CollectionProjects { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollectionProject>()
                .HasKey(cp => new { cp.CollectionId, cp.ProjectId });

            modelBuilder.Entity<CollectionProject>()
                .HasOne(cp => cp.Collection)
                .WithMany(c => c.CollectionProjects)
                .HasForeignKey(cp => cp.CollectionId);

            modelBuilder.Entity<CollectionProject>()
                .HasOne(cp => cp.Project)
                .WithMany(p => p.CollectionProjects)
                .HasForeignKey(cp => cp.ProjectId);
        }
    }
}