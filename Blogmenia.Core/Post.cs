using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blogmenia.Core
{


    public partial class Post
    {
        public Post()
        {
            Postcategory = new HashSet<Postcategory>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string Content { get; set; }
        public string FeaturedImg { get; set; }
        public string Rating { get; set; }
        public string AuthorId { get; set; }
        public int PrimaryCategoryId { get; set; }
        public int? CommentCount { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Status { get; set; }
        public string SendMail { get; set; }
        public string SortName { get; set; }
        public string IsFeatured { get; set; }
        public string MultipleCategory { get; set; }
              
          public virtual ICollection<Postcategory> Postcategory { get; set; }
    }
}
