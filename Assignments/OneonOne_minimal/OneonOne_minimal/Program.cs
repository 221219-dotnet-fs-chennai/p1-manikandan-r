using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PlaceDBContext>(options =>
options.UseInMemoryDatabase("PlacesList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("Places/Getall", (PlaceDBContext pl) => pl.Places.ToListAsync());

app.MapGet("Places/GetbyID/{id}", (int id, PlaceDBContext pl) =>
    pl.Places.FindAsync(id));

app.MapPost("Places/Post", (Places p, PlaceDBContext pl) =>
{
    pl.Places.Add(p);
    pl.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("Places/Put/{id}", async (int id, Places p, PlaceDBContext pl) =>
{
    var val = await pl.Places.FindAsync(id);
    if (val is null) return Results.NotFound();
    val.place = p.place;
    val.country = p.country;
    pl.SaveChangesAsync();
    return Results.Ok();
});

app.MapDelete("Place/Delete/{id}", async (int id, PlaceDBContext pl) =>
{
    if (await pl.Places.FindAsync(id) is Places p)
    {
        pl.Places.Remove(p);
        await pl.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();

});

app.Run();

public class Places
{
    public int Id { get; set; }
    public string place { get; set; }
    public string country { get; set; }
}

public class PlaceDBContext : DbContext
{
    public PlaceDBContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Places> Places { get; set; }
}