using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RecipeApi.Entities;

namespace RecipeApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new() { Id = 1, Name = "Soepen" },
               new() { Id = 2, Name = "Vegetarisch" },
               new() { Id = 3, Name = "Voorgerecht" },
               new() { Id = 4, Name = "Hoofdgerecht" },
               new() { Id = 5, Name = "Dessert" }
           );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
