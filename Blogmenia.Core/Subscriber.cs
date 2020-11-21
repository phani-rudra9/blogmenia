using System;
using System.ComponentModel.DataAnnotations;

namespace Blogmenia.Core
{
    public partial class Subscriber
    {
        [Key]
        public int SubscriberId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailId { get; set; }
        public string IpAddress { get; set; }
        public string OperatingSystemType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ActionType { get; set; }
        public string IsVerified { get; set; }
    }
}
