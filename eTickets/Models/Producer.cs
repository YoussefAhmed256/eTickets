using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer : IEntityBase
    {
        public int Id { get; set; }
        [Display(Name = "ProfilePicture")]
        [Required(ErrorMessage ="Profile Picture is Required")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "FullName")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }
        // Relationships
        public List<Movie> Movies { get; set; } 
    }
}
