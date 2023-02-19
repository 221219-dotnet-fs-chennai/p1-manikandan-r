using Bussiness_Logic;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Trainer_EF_Layer.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var trainer_config = builder.Configuration.GetConnectionString("TrainerDBConnection");
builder.Services.AddDbContext<TrainerDbContext>(options => options.UseSqlServer(trainer_config));
builder.Services.AddScoped<ILogic, Logic>();
builder.Services.AddScoped<Validation,Validation>();

//var AllowPages = "Allowpages";
//builder.Services.AddCors(options =>
//options.AddPolicy(AllowPages, policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); })) ;

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
