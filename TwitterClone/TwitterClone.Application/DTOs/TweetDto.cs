using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Application.DTOs
{
    public class TweetDto
    {
        public required Guid Id { get; set; }
        public required Guid UserID { get; set; }
        public required string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

    }
}
