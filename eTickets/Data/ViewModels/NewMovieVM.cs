using eTickets.Data.Base;
using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace eTickets.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }
        [Display(Name = "Movie name")]
        [Required(ErrorMessage = "Movie name is required")]
        public string Name { get; set; }
        [Display(Name = "Movie description")]
        [Required(ErrorMessage = "Movie description is required")]
        public string Description { get; set; }
        [Display(Name = "Movie image URL")]
        [Required(ErrorMessage = "Movie image URL is required")]
        public string ImageUrl { get; set; }
        [Display(Name = "Movie start date")]
        [Required(ErrorMessage = "Movie start date is required")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Movie end date")]
        [Required(ErrorMessage = "Movie end date is required")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Movie price is required")]
        public double Price { get; set; }
        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Movie category is required")]
        public MovieCategory MovieCategory { get; set; }
        [Display(Name = "Select a cinema")]
        [Required(ErrorMessage = "Cinema is required")]
        public int CinemaId { get; set; }
        [Display(Name = "Select a Producer")]
        [Required(ErrorMessage = "Producer is required")]
        public int ProducerId { get; set; }
        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "At least one actor is required")]
        public List<int> ActorIds { get; set; }
    }
}
