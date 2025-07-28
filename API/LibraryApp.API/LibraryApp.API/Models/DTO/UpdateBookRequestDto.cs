using System.ComponentModel.DataAnnotations;

namespace LibraryApp.API.Models.DTO
{
    public class UpdateBookRequestDto
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Author { get; set; }

        [Range(1000, 2100)]
        public int Year { get; set; }

        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }
    }
}
