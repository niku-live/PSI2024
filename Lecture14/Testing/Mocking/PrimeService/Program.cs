using Microsoft.EntityFrameworkCore;
using Prime.Data;
using Prime.Repositories;
using Prime.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IPrimeService, PrimeService>();
builder.Services.AddTransient<IPrimeRepository, PrimeRepository>();
builder.Services.AddControllers();
builder.Services.AddDbContext<PrimeDbContext>(opt => opt.UseInMemoryDatabase("NumbersList"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (true) //(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();