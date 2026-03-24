using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Entity
{
    public class Category
    {
        //CRUD : Create, Read, Update, Delete

        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "Name of Category")]
        public string Name { get; set; } = String.Empty;

        [Display(Name = "Category Description")]
        public string? Description { get; set; }

        [Display(Name = "Category Is Active?")]
        public bool IsActive { get; set; } = false;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateAt { get; set; }
    }
}
