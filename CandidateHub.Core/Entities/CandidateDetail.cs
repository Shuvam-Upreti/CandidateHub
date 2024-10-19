using System;
using System.Collections.Generic;

namespace CandidateHub.Core.Entities;

public partial class CandidateDetail
{
    public int CandidateId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string Email { get; set; } = null!;

    public string? CallTimeInterval { get; set; }

    public string? LinkedInProfileUrl { get; set; }

    public string? GitHubProfileUrl { get; set; }

    public string FreeTextComment { get; set; } = null!;
}
