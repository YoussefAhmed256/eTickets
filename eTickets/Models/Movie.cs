﻿using eTickets.Data.Base;
using eTickets.Data.Enums;
using System.Runtime.InteropServices;

namespace eTickets.Models
{
    public class Movie : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public MovieCategory MovieCategory { get; set; } 
        // Relationships
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
