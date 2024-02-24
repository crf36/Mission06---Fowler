using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06___ChrisFowler.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required (ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a year")]
        [Range(1888, int.MaxValue, ErrorMessage = "Enter a year 1888 or greater")]
        public int? Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required (ErrorMessage = "Please enter if the movie was edited")]
        public int Edited { get; set; }

        public string? LentTo { get; set; }

        [Required (ErrorMessage = "Please enter if the movie has been copied to Plex")]
        public int CopiedToPlex { get; set; }

        [StringLength(25, ErrorMessage = "Please keep the length of the note under 25 characters")]
        public string? Notes { get; set; } // Max length of 25 both here and in the form
    }
}
