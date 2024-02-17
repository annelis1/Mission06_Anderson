using System.ComponentModel.DataAnnotations;

namespace Mission06_Anderson.Models
{
    public class Submission
    {
        [Key]
        [Required]
        public int SubmissionId { get; set; }
        public string Category { get; set; }
        public string? Category2 { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? Lent { get; set; }
        
        //limit string length and send error message if exceeded
        [StringLength(25, ErrorMessage = "Notes can't be longer than 25 characters")]
        public string? Notes { get; set; }
    }
}
