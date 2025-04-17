namespace Backend.Domain.Entities;

public class Flashcard
{
  public int Id { get; set; }
  public string Front { get; set; } = null!;
  public string Back { get; set; } = null!;
}
