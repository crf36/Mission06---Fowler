using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06___ChrisFowler.Models
{
    public class NewMovie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Categories? Category { get; set; }

        [Required(ErrorMessage = "You must enter a title!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You must enter a year!")]
        [Range(1888, int.MaxValue, ErrorMessage = "The year must be 1888 or later!")]
        public int? Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "You must enter whether a movie has been edited!")]
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "You must enter whether the movie has been copied to Plex!")]
        public bool? CopiedToPlex { get; set; }

        [Range(0, 25)]
        public string? Notes { get; set; } // Max length of 25 both here and in the form
    }
}
