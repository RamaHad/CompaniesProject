using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ApplicationDbContext : DbContext
    {
        
        public DbSet<Company> Companies { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<Distribution> Distributions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder Builder)
        {
            base.OnConfiguring(Builder);
            Builder.UseSqlServer(@"Data Source=DESKTOP-79PJ7V9\SQLEXPRESS;Initial Catalog=Task;Integrated Security=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);

            Builder.Entity<Company>()
                .HasMany<Branch>()
                .WithOne(b => b.Company)
                .HasForeignKey(b => b.CompanyId);

            Builder.Entity<Branch>()
                .HasMany<Branch>()
                .WithOne(b => b.MainBranch)
                .HasForeignKey(b => b.MainBranchId)
                .OnDelete(DeleteBehavior.ClientCascade);


            Builder.Entity<Item>()
                .HasMany<Production>()
                .WithOne(b => b.Item)
                .HasForeignKey(b => b.ItemId);

            Builder.Entity<Branch>()
               .HasMany<Production>()
               .WithOne(b => b.Branch)
               .HasForeignKey(b => b.BranchId);

            Builder.Entity<Branch>()
              .HasMany<Distribution>()
              .WithOne(b => b.DistributionBranch)
              .HasForeignKey(b => b.DistributionBranchId);

            Builder.Entity<Production>()
              .HasMany<Distribution>()
              .WithOne(b => b.Production)
              .HasForeignKey(b => b.ProductionId)
              .OnDelete(DeleteBehavior.ClientCascade);

        }


    }
}
