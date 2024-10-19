using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateHub.Core.Dto
{
    public class CandidateDetailDto
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = null!;

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = null!;

        public string? CallTimeInterval { get; set; }

        [Url(ErrorMessage = "Invalid LinkedIn profile URL.")]
        public string? LinkedInProfileUrl { get; set; }

        [Url(ErrorMessage = "Invalid GitHub profile URL.")]
        public string? GitHubProfileUrl { get; set; }
        [Required(ErrorMessage = "Comment is required.")]
        public string FreeTextComment { get; set; } = null!;
    }
}
