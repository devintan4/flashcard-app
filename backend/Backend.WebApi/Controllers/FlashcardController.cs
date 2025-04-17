using Backend.Application.Interfaces;
using Backend.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlashcardsController : ControllerBase
{
  private readonly IFlashcardRepository _repo;
  public FlashcardsController(IFlashcardRepository repo) => _repo = repo;

  [HttpGet]
  public async Task<IActionResult> GetAll() =>
      Ok(await _repo.GetAllAsync());

  [HttpGet("{id:int}")]
  public async Task<IActionResult> Get(int id)
  {
    var dto = await _repo.GetByIdAsync(id);
    return dto is null ? NotFound() : Ok(dto);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] FlashcardDto dto)
  {
    var created = await _repo.CreateAsync(dto);
    return CreatedAtAction(nameof(Get),
      new { id = created.Id }, created);
  }
}
