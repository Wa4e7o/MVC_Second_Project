namespace MovieSystem.Data
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using MovieSystem.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class MovieSystemDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MovieSystemDbContext>();

                context.Database.EnsureCreated();

                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "https://www.cinemacity.bg/xmedia/img/10106/default-placeholder.png",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "https://storyfactory.uk/wp-content/uploads/2020/01/sky-cinema-nowtv.png",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "http://themall.bg/wp-content/uploads/2016/07/arenathemall-logo.jpg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                    });
                    context.SaveChanges();
                }

                if (!context.Actiors.Any())
                {

                }

                if (!context.Producers.Any())
                {

                }

                if (!context.Movies.Any())
                {

                }

                if (!context.ConnectionTables.Any())
                {

                }
            }
        }
    }
}
