﻿using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context) 
        {
            _context=context;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                ImageUrl = data.ImageUrl,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                Price = data.Price,
                MovieCategory = data.MovieCategory,
                CinemaId = data.CinemaId,
                ProducerId = data.ProducerId
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);
            return await movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync(),
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync()
            };
            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies
                .FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.ImageUrl = data.ImageUrl;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.Price = data.Price;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();
            }
            var existingActorsDb = _context.Actors_Movies
                .Where(n => n.MovieId == data.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}
