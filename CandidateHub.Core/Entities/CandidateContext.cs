using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CandidateHub.Core.Entities;

public partial class CandidateContext : DbContext
{
    public CandidateContext(DbContextOptions<CandidateContext> options)
        : base(options)
    {
    }

}
