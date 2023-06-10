using Microsoft.EntityFrameworkCore;
using song_lyrics_finder.BLL;
using song_lyrics_finder.DAL.DBContext;
using song_lyrics_finder.MODEL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<LyricfinderDBContext>(opt => opt.UseSqlServer("C:\\Users\\arthu\\OneDrive\\Documentos\\pessoal\\projetos\\backend-song-lyrics-finder\\song-lyrics-finder\\song-lyrics-finder.DAL\\Database\\LyricFinderDB.mdf"));
builder.Services.AddScoped<ISongRepository, SongRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
