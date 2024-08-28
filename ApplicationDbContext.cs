using Farmer_Issues.Models;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;


namespace Farmer_Issues
{
   
        public class ApplicationDbContext : DbContext
        {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Fertilizer> Fertilizers { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<ResolvedIssue> ResolvedIssues { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)

            {
                optionsBuilder.UseSqlServer(@"Server=USGURDSAMAD06;Database=Farmer_Fertilizer;Trusted_Connection=True;");
            }
           // base.OnConfiguring(optionsBuilder);
        }

        
    }

    
}
