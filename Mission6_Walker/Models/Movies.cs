using System.Collections.Generic;
using System.Reflection.Emit;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Walker.Models
{
    public class Movies
    {
        [Key] 
        [Required] 
        public int MovieId { get; set; }

        [ForeignKey("Categories")]
        public int? CategoryId { get; set; }
        public Categories? Categories { get; set; }

        [Required(ErrorMessage = "Movie needs a title to be submitted to the database.")] 
        public string Title { get; set; }

        [Required(ErrorMessage = "The year needs to be between 1888 and the current year.")] 
        [Range(1888, 2024)]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }
        
        [Required] 
        public bool Edited { get; set; }
        
        public string? LentTo {  get; set; }
        
        [Required] 
        public bool CopiedToPlex {  get; set; }
        
        [StringLength(25, ErrorMessage = "Notes field needs to be shorter than 25 characters.")] 
        public string? Notes {  get; set; }

    }
}
