using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateHub.Core.Dto
{
    public class CandidateDetailDto
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string Email { get; set; } = null!;

        public string? CallTimeInterval { get; set; }

        public string? LinkedInProfileUrl { get; set; }

        public string? GitHubProfileUrl { get; set; }

        public string FreeTextComment { get; set; } = null!;
    }
}
