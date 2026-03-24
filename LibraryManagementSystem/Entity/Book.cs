using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Entity
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Author { get; set; }
        public int CategoryId { get; set; }

        [Range (0,100000)]
        public decimal price { get; set; }
        public string? CoverUrl { get; set; }
      

    }
}
