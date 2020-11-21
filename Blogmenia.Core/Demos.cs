using System.ComponentModel.DataAnnotations;

namespace Blogmenia.Core
{
    public partial class Demos
    {
        [Key]
        public int DemoId { get; set; }
        public string Slug { get; set; }
        public string ContentBody { get; set; }
        public string PostLink { get; set; }
        public string PostUrl { get; set; }
        public string DemoTitle { get; set; }
        public int? PostId { get; set; }
    }
}
