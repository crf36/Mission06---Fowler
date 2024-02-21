using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06___ChrisFowler.Models
{
    public class Application
    {
        [Key]
        [Required]
        public int MovieID { get; set; } // Primary Key, set automatically
        [Required]
        [ForeignKey("CategoryId")]
        public string CategoryId { get; set; }
        public Categories Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; } // I did a string because in the excel file, he has some that are 2005-2011
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool? Edited { get; set; } // Note: Professor Hilton said in slack he didn't think this one through with bool
                                          // so he said we can force them to choose true or false, since bool only stores 0 or 1
        public string? LentTo { get; set; }
        public bool? CopiedToPlex { get; set; }
        [Range(0, 25)]
        public string? Notes { get; set; } // Max length of 25 both here and in the form
    }
}
