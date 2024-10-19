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

    public virtual DbSet<CandidateDetail> CandidateDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CandidateDetail>(entity =>
        {
            entity.HasKey(e => e.CandidateId).HasName("PK__Candidat__DF539B9C9FD42303");

            entity.ToTable("CandidateDetail");

            entity.HasIndex(e => e.Email, "UQ__Candidat__A9D1053462AE9A2F").IsUnique();

            entity.Property(e => e.CallTimeInterval).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.GitHubProfileUrl).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.LinkedInProfileUrl).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
