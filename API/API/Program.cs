using API.Data;
using API.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// create webapplication builder classs which then we can use for inject dependency into services collection
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// registering dbcontext to service container 
builder.Services.AddDbContext<APIDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIConnection"));

});

builder.Services.AddScoped<IRegioRepo,RegionRepo>();

//builder.Services.AddDbContext<APIDBContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("APIConnection"));
//});

// AUTOMAPPER 
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//http pipeline
app.UseAuthorization();

app.MapControllers();

app.Run();
