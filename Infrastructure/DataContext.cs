using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PortItem>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Owner>().HasData(
                new Owner()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Mohamed Ali",
                    Description = ".Net Full Stack Deveolper",
                    AvatarUrl= "mas.bmp",
                }
                );
        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PortItem> PortItems { get; set; }
    }
}
