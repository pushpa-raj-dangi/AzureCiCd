

using CandidateApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CandidateApp.Infrastructure.Data;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Candidate> Candidates { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Candidate>().HasKey(c => c.Id);
        modelBuilder.Entity<Candidate>().HasIndex(c => c.Email).IsUnique();
    }
}
