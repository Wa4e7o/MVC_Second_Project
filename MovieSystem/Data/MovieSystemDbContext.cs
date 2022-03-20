namespace MovieSystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class MovieSystemDbContext : IdentityDbContext
    {
        public MovieSystemDbContext(DbContextOptions<MovieSystemDbContext> options)
            : base(options)
        {
        }
    }
}
