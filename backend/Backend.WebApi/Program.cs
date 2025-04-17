using Backend.Application.Interfaces;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1) EF Core DbContext
builder.Services.AddDbContext<FlashcardDbContext>(opts =>
    opts.UseSqlite(builder.Configuration.GetConnectionString("Default")));

// 2) DI untuk repos & layanan Application (Step 10)
builder.Services.AddScoped<IFlashcardRepository, FlashcardRepository>();

// 3) Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
