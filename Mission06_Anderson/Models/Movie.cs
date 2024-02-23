using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Anderson.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage ="Must enter movie title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Must enter release year of the movie")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later")]
        public int Year { get; set; }
        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Must enter edited status")]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }

        [Required(ErrorMessage ="Specify if the movie has been copied to Plex media library")]
        public bool CopiedToPlex { get; set; }
        
        //limit string length and send error message if exceeded
        [StringLength(25, ErrorMessage = "Notes can't be longer than 25 characters")]
        public string? Notes { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
