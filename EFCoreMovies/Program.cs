using EFCoreMovies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
       .AddDbContext<AppDbContext>(opt => {
           opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); //Its good idea to make NoTracking that default behaviour of queries
           opt.UseSqlServer("name=defaultConnection", sql => sql.UseNetTopologySuite());
           });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
