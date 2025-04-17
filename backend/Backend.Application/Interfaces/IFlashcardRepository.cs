using Backend.Application.Models;

namespace Backend.Application.Interfaces;

public interface IFlashcardRepository
{
  Task<List<FlashcardDto>> GetAllAsync(CancellationToken ct = default);
  Task<FlashcardDto?> GetByIdAsync(int id, CancellationToken ct = default);
  Task<FlashcardDto> CreateAsync(FlashcardDto dto, CancellationToken ct = default);
}
