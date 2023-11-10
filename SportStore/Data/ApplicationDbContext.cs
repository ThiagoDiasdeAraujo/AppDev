using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SportStore.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace SportStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SportStore;Trusted_Connection=True");
        //}

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

            modelBuilder.Entity<Product>()
               .HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(x => x.CategoryId)
			   .IsRequired()
			   .OnDelete(DeleteBehavior.Cascade);
		}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}