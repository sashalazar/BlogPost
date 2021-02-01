using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BlogPost.WebAPI.ViewModels.RequestModels
{
    public class PostRequest : IValidatableObject
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime PostDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (PostDate > DateTime.UtcNow)
            {
                errors.Add(new ValidationResult("The date cannot be in the future", new List<string>() { "PostDate" }));
            }

            return errors;
        }
    }
}
