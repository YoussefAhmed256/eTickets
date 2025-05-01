using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer
    {
        public int Id { get; set; }
        [Display(Name = "ProfilePicture")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "FullName")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        // Relationships
        public List<Movie> Movies { get; set; } 
    }
}
