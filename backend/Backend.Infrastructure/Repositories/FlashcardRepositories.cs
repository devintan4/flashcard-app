using Backend.Application.Interfaces;
using Backend.Application.Models;
using Backend.Domain.Entities;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories;

public class FlashcardRepository : IFlashcardRepository
{
  private readonly FlashcardDbContext _db;
  public FlashcardRepository(FlashcardDbContext db) => _db = db;

  public async Task<List<FlashcardDto>> GetAllAsync(CancellationToken ct = default) =>
      await _db.Flashcards
        .Select(f => new FlashcardDto
        {
          Id = f.Id,
          Front = f.Front,
          Back = f.Back
        })
        .ToListAsync(ct);

  public async Task<FlashcardDto?> GetByIdAsync(int id, CancellationToken ct = default) =>
      await _db.Flashcards
        .Where(f => f.Id == id)
        .Select(f => new FlashcardDto
        {
          Id = f.Id,
          Front = f.Front,
          Back = f.Back
        })
        .FirstOrDefaultAsync(ct);

  public async Task<FlashcardDto> CreateAsync(FlashcardDto dto, CancellationToken ct = default)
  {
    var entity = new Flashcard
    {
      Front = dto.Front,
      Back = dto.Back
    };
    _db.Flashcards.Add(entity);
    await _db.SaveChangesAsync(ct);
    dto.Id = entity.Id;
    return dto;
  }
}
