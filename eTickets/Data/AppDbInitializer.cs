using eTickets.Data.Enums;
using eTickets.Models;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                // Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "https://example.com/logo1.png",
                            Description = "Description 1"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "https://example.com/logo2.png",
                            Description = "Description 2"
                        }
                    });
                    context.SaveChanges();
                }
                // Producer
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "Bio 1",
                            ProfilePictureUrl = "https://example.com/profile1.png"
                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "Bio 2",
                            ProfilePictureUrl = "https://example.com/profile2.png"
                        }
                    });
                    context.SaveChanges();
                }
                // Actor
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "Bio 1",
                            ProfilePictureUrl = "https://example.com/actor1.png"
                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "Bio 2",
                            ProfilePictureUrl = "https://example.com/actor2.png"
                        }
                    });
                    context.SaveChanges();
                }
                // Movie
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Movie 1",
                            Description = "Description 1",
                            Price = 10.99,
                            ImageUrl = "https://example.com/movie1.png",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Movie 2",
                            Description = "Description 2",
                            Price = 12.99,
                            ImageUrl = "https://example.com/movie2.png",
                            StartDate = DateTime.Now.AddDays(-5),
                            EndDate = DateTime.Now.AddDays(15),
                            CinemaId = 2,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Comedy
                        }
                    });
                    context.SaveChanges();
                }
                // Actor_Movie
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 2
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
