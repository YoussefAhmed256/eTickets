using eTickets.Data.Enums;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

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

        public static async Task seedUsersAndRolesAsync (IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser
                    {
                        FullName = "Youssef Ahmed",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        UserName = "Admin"
                    };
                    await userManager.CreateAsync (newAdminUser,"Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser
                    {
                        FullName = "user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        UserName = "AppUser"
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
