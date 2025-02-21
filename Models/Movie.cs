using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission07_Keeney.Models
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        [Column("MovieId")]
        public int MovieId { get; set; }

        [Column("CategoryId")]
        public int? CategoryId { get; set; }

        [Required]
        [Column("Title")]
        public string Title { get; set; }

        [Required]
        [Column("Year", TypeName = "INTEGER")]  // 🔹 Force EF to recognize Year as INTEGER
        [Range(1888, 2100, ErrorMessage = "Year must be between 1888 and 2100.")]
        public int Year { get; set; }

        [Column("Director")]
        public string? Director { get; set; }

        [Column("Rating")]
        public string? Rating { get; set; }

        [Required]
        [Column("Edited")]
        public bool Edited { get; set; }

        [Column("LentTo")]
        public string? LentTo { get; set; }

        [Required]
        [Column("CopiedToPlex")]
        public bool CopiedToPlex { get; set; }

        [Column("Notes")]
        [StringLength(25)]
        public string? Notes { get; set; }
    }
}