using System.ComponentModel.DataAnnotations;

namespace Blogmenia.Core
{
    public partial class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    }
}
