using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Template_Web_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
