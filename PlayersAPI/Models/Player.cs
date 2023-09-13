using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayersAPI.Models
{
    [Table("Players")]
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        [StringLength(80)]
        public string? Name { get; set; }

        [Required]
        [StringLength(80)]
        public string? Team { get; set; }

        public int Number { get; set; }

        [Required]
        [StringLength(80)]
        public string? Position { get; set; }
        public int Age { get; set; }

        [Required]
        public int FifaScore { get; set; }
    }
}
