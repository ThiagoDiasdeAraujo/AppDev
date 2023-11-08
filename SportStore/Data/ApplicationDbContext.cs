using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportStore.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace SportStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        //Aangezien de categorieën weinig zullen veranderen tijdens de loop van de applicatie, kunnen gebruik maken van seeding om een aantal categorieën vast in de databank te zetten bij het opstartenvan de applicatie.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new() { Id = 1, Name = "Football" },
                new() { Id = 2, Name = "Snowboarding" },
                new() { Id = 3, Name = "Freerunning" },
                new() { Id = 4, Name = "Underwater Hockey" },
                new() { Id = 5, Name = "Cheese Rolling" }
            );
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}