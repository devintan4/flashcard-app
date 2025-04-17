namespace Backend.Application.Models;

public class FlashcardDto
{
  public int Id { get; set; }
  public string Front { get; set; } = null!;
  public string Back { get; set; } = null!;
}
