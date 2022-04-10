namespace MovieSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using MovieSystem.Data.Models;

    public class MovieSystemDbContext : DbContext
    {
        public MovieSystemDbContext(DbContextOptions<MovieSystemDbContext> options)
            : base(options)
        {

        }

        public DbSet<Actior> Actiors { get; init; }

        public DbSet<Cinema> Cinemas { get; init; }

        public DbSet<Movie> Movies { get; init; }

        public DbSet<Producer> Producers { get; init; }

        public DbSet<ConnectionTable> ConnectionTables { get; init; }

        public DbSet<Order> Orders { get; init; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .Entity<ConnectionTable>()
               .HasKey(c => new
               {
                   c.ActiorId,
                   c.MovieId
               });

            builder
               .Entity<ConnectionTable>()
               .HasOne(a => a.Actior)
               .WithMany(c => c.ConnectionTables)
               .HasForeignKey(a => a.ActiorId)
               .OnDelete(DeleteBehavior.Restrict);


            builder
               .Entity<ConnectionTable>()
               .HasOne(a => a.Movie)
               .WithMany(c => c.ConnectionTables)
               .HasForeignKey(a => a.MovieId)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}

