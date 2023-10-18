using Microsoft.EntityFrameworkCore;

namespace Routing.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Club> Clubs { get; set; }
	}
}
