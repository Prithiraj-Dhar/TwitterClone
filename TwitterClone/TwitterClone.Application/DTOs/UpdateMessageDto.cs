using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Application.DTOs
{
    public class UpdateMessageDto
    {
        [Required]
        [StringLength(1000)]
        public required string Content { get; set; }
    }
}
