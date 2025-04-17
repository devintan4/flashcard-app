using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Data;

public class FlashcardDbContext : DbContext
{
  public FlashcardDbContext(DbContextOptions<FlashcardDbContext> opts)
      : base(opts) { }

  public DbSet<Flashcard> Flashcards => Set<Flashcard>();

  protected override void OnModelCreating(ModelBuilder mb)
  {
    mb.Entity<Flashcard>()
      .Property(f => f.Front)
      .IsRequired();
    mb.Entity<Flashcard>()
      .Property(f => f.Back)
      .IsRequired();
  }
}
