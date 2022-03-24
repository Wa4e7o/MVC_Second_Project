namespace MovieSystem.Data
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using MovieSystem.Data.Models;
    using MovieSystem.Models.Enums;
    using System;
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
                            Logo = "https://mir-s3-cdn-cf.behance.net/project_modules/1400_opt_1/47379962105723.5a84ee1395f12.png",
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
                    context.Actiors.AddRange(new List<Actior>()
                    {
                        new Actior()
                        {
                            Name = "Eddie Murph",
                            Biography = "Eddie Murphy, byname of Edward Regan Murphy, (born April 3, 1961, Brooklyn, New York, U.S.), American comedian, actor, and singer who was a dominant comedic voice in the United States during the 1980s. His comedy was largely personal and observational and at times raunchy and cruel. He was also a skillful impersonator.",
                            ImageURL = "https://cdn.britannica.com/47/206347-050-18285180/Eddie-Murphy-2007.jpg"

                        },
                        new Actior()
                        {
                            Name = "Brad Pitt",
                            Biography = "An actor and producer known as much for his versatility as he is for his handsome face, Golden Globe-winner Brad Pitt's most widely recognized role may be Tyler Durden in Fight Club (1999).",
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BMjA1MjE2MTQ2MV5BMl5BanBnXkFtZTcwMjE5MDY0Nw@@._V1_UX214_CR0,0,214,317_AL_.jpg"
                        },
                        new Actior()
                        {
                            Name = "Robart De Niro",
                            Biography = "One of the greatest actors of all time, Robert De Niro was born on August 17, 1943 in Manhattan, New York City, to artists Virginia (Admiral) and Robert De Niro Sr.De Niro first gained fame for his role in Bang the Drum Slowly (1973), but he gained his reputation as a volatile actor in Mean Streets (1973), which was his first film with director Martin Scorsese.",
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BMjAwNDU3MzcyOV5BMl5BanBnXkFtZTcwMjc0MTIxMw@@._V1_UY317_CR13,0,214,317_AL_.jpg"
                        },
                        new Actior()
                        {
                            Name = "Denzel Washington",
                            Biography = "Denzel Hayes Washington, Jr. was born on December 28, 1954 in Mount Vernon, New York. He is the middle of three children of a beautician mother, Lennis, from Georgia, and a Pentecostal minister father, Denzel Washington, Sr., from Virginia.He continued to define his onscreen persona as the tough, no-nonsense hero through the 2000s in films like Out of Time (2003), Man on Fire (2004), Inside Man (2006), and The Taking of Pelham 1 2 3 (2009)",
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BMjE5NDU2Mzc3MV5BMl5BanBnXkFtZTcwNjAwNTE5OQ@@._V1_UY317_CR12,0,214,317_AL_.jpg"
                        },
                        new Actior()
                        {
                            Name = "Russell Crowe",
                            Biography = "Russell Ira Crowe was born in Wellington, New Zealand, to Jocelyn Yvonne (Wemyss) and John Alexander Crowe, both of whom catered movie sets.Beginning as a child star on a local Australian TV show, Russell's first big break came with two films ... the first, Romper Stomper (1992), gained him a name throughout the film community in Australia and the neighboring countries.",
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BMTQyMTExNTMxOF5BMl5BanBnXkFtZTcwNDg1NzkzNw@@._V1_UX214_CR0,0,214,317_AL_.jpg"
                        }
                    });

                    context.SaveChanges();
                }

                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            Name = "Francis Ford Coppola",
                            Biography = "Francis Ford Coppola was born in 1939 in Detroit, Michigan, but grew up in a New York suburb in a creative, supportive Italian-American family.",
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BMTM5NDU3OTgyNV5BMl5BanBnXkFtZTcwMzQxODA0NA@@._V1_UX214_CR0,0,214,317_AL_.jpg"

                        },
                        new Producer()
                        {
                            Name = "Kevin Feige",
                            Biography = "Kevin Feige is an American film producer who has produced every Marvel Cinematic Universe film since Iron Man. He got his start as an associate and executive producer for the Sam Raimi Spider-Man films, Daredevil, The Punisher, Ang Lee's Hulk, the original X-Men trilogy, Blade: Trinity and Tim Story's Fantastic Four films.",
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BMzU4NDY5Mzk3MV5BMl5BanBnXkFtZTgwNzMyMTY1MDE@._V1_UY317_CR14,0,214,317_AL_.jpg"
                        },
                        new Producer()
                        {
                            Name = "Kathleen Kennedy",
                            Biography = "Eight-time Academy Award®-nominated, Kathleen Kennedy is one of the most successful and respected producers and executives in the film industry today. As President of Lucasfilm, she oversees the company's three divisions: Lucasfilm, Industrial Light & Magic and Skywalker Sound.",
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BOTQ4OTM5NzA0MF5BMl5BanBnXkFtZTcwMzE3MjA0Nw@@._V1_UY317_CR1,0,214,317_AL_.jpg"
                        },
                        new Producer()
                        {
                            Name = "David Heyman",
                            Biography = "David Heyman was born on July 26, 1961 in London, England. He is a producer and actor, known for Gravity (2013), Marriage Story (2019) and Once Upon a Time... In Hollywood (2019).",
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BMTYwNzE2MDgxM15BMl5BanBnXkFtZTcwMTIwMDY4NQ@@._V1_UY317_CR104,0,214,317_AL_.jpg"
                        },
                        new Producer()
                        {
                            Name = "Neal H. Moritz",
                            Biography = "Neal H. Moritz is an American film and television producer who was born on June 6, 1959. After graduating from college at Westwood, he earned a master's degree in 1985, which led to a startup of his own production company Neal Moritz Productions. He had a production deal with Paramount Pictures.",
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BODY1MDY0NDk5Nl5BMl5BanBnXkFtZTgwNTg4ODMwNzE@._V1_UX214_CR0,0,214,317_AL_.jpg"
                        }
                    });

                    context.SaveChanges();
                }

                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImgUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImgUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImgUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImgUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImgUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImgUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Drama
                        }
                    });

                    context.SaveChanges();
                }

                if (!context.ConnectionTables.Any())
                {
                    context.ConnectionTables.AddRange(new List<ConnectionTable>()
                    {
                    new ConnectionTable()
                    {
                        ActorId = 1,
                        MovieId = 1
                    },
                    new ConnectionTable()
                    {
                        ActorId = 3,
                        MovieId = 1
                    },

                    new ConnectionTable()
                    {
                        ActorId = 1,
                        MovieId = 2
                    },
                    new ConnectionTable()
                    {
                        ActorId = 4,
                        MovieId = 2
                    },

                    new ConnectionTable()
                    {
                        ActorId = 1,
                        MovieId = 3
                    },
                    new ConnectionTable()
                    {
                        ActorId = 2,
                        MovieId = 3
                    },
                    new ConnectionTable()
                    {
                        ActorId = 5,
                        MovieId = 3
                    },

                    new ConnectionTable()
                    {
                        ActorId = 2,
                        MovieId = 4
                    },
                    new ConnectionTable()
                    {
                        ActorId = 3,
                        MovieId = 4
                    },
                    new ConnectionTable()
                    {
                        ActorId = 4,
                        MovieId = 4
                    },

                    new ConnectionTable()
                    {
                        ActorId = 2,
                        MovieId = 5
                    },
                    new ConnectionTable()
                    {
                        ActorId = 3,
                        MovieId = 5
                    },
                    new ConnectionTable()
                    {
                        ActorId = 4,
                        MovieId = 5
                    },
                    new ConnectionTable()
                    {
                        ActorId = 5,
                        MovieId = 5
                    },


                    new ConnectionTable()
                    {
                        ActorId = 3,
                        MovieId = 6
                    },

                    new ConnectionTable()
                    {
                        ActorId = 4,
                        MovieId = 6
                    },
                    new ConnectionTable()
                    {
                        ActorId = 5,
                        MovieId = 6
                    },
                });
                    context.SaveChanges();
                }
            }
        }
    }
}


