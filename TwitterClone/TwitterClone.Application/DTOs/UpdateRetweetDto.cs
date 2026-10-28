using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Application.DTOs
{
    public class UpdateRetweetDto
    {
        public string? Comment { get; set; }

        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            if (Comment != null && Comment.Length > 280)
            {
                yield return new ValidationResult(
                    "Retweet comment cannot exceed 280 characters.",
                    new[] { nameof(Comment) }
                );
            }
        }
    }
}
