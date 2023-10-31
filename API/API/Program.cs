using API.Data;
using API.Middleware;
using API.Repo;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// create webapplication builder classs which then we can use for inject dependency into services collection
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
        options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
        {
            Name= "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = JwtBearerDefaults.AuthenticationScheme
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement

        {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
                Scheme = "Oauth2",
                Name = JwtBearerDefaults.AuthenticationScheme,
                In = ParameterLocation.Header
            },
            new List<string>()
          }
        });
    }
    );
builder.Services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Program>());

// registering dbcontext to service container 
builder.Services.AddDbContext<APIDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIConnection"));

});

builder.Services.AddDbContext<APIDBContextAuth>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIAuthConnection"));

});

//logging error
var logger = new LoggerConfiguration().WriteTo.Console().
    WriteTo.File("logs/API_Log.txt",rollingInterval:RollingInterval.Minute).
    MinimumLevel.Warning().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddScoped<IRegioRepo,RegionRepo>();

builder.Services.AddScoped<IImage, ImageRepo>();

builder.Services.AddScoped<IWalkRepo, WalkRepo>();

builder.Services.AddScoped<IWalkDiffRepo, WalkDiffRepo>();

builder.Services.AddScoped<IInfoRepo, InfoRepo>();

builder.Services.AddScoped<ITokenHandler, API.Repo.TokenHandler>();

builder.Services.AddSingleton<IUserValid, StaticUserValidation>();

//builder.Services.AddDbContext<APIDBContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("APIConnection"));
//});

// AUTOMAPPER 
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// identity 
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("APIDB")
    .AddEntityFrameworkStores<APIDBContextAuth>()
    .AddDefaultTokenProviders();

// identity options
builder.Services.Configure<IdentityOptions>(options =>
{ 
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});
//Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience= true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer= builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    });

var app = builder.Build();

// reset pwd.
//builder.Services.Configure<DataProtectionTokenProviderOptions>(options => 
//options.TokenLifespan = TimeSpan.FromHours(3));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExpectionHandlerMiddleWare>();
app.UseHttpsRedirection();


app.UseStaticFiles(new StaticFileOptions
{
    FileProvider =new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"Image")),
    RequestPath= "/Image"

});
//http pipeline
app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
