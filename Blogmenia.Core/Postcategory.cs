using System.ComponentModel.DataAnnotations;

namespace Blogmenia.Core
{
    public partial class Postcategory
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CategoryId { get; set; }

        public virtual Post Post { get; set; }
    }
}
