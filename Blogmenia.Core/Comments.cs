using System;
using System.ComponentModel.DataAnnotations;

namespace Blogmenia.Core
{
    public partial class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string AuthorName { get; set; }

        [Required]
        public string AuthorEmail { get; set; }
        public string AuthorWebsite { get; set; }
        public string AuthorIp { get; set; }
        public DateTime CommentDate { get; set; }
        public DateTime CommentDateGmt { get; set; }

        [Required]
        public string Message { get; set; }
        public string Karma { get; set; }
        public string Status { get; set; }
        public string CommentAgent { get; set; }
        public string Type { get; set; }
        public int? ParentCommentId { get; set; }
        public int? UserId { get; set; }
        public int? IsAdmin { get; set; }
    }
}
