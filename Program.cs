
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using WAIGR_Users_Products.Context;
using WAIGR_Users_Products.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(cnfg =>
    {
        cnfg.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "CRUD API",
            Description = "Evaluación de Ingreso ",
            Contact = new OpenApiContact
            {
                Name = "Jaciel Israel Reséndiz Ochoa",
                Email = "resendiz.jiro@yopmail.com",
                Url = new Uri("https://github.com/reoj")
            },
            Version = "v1.4"
        }
        );
    }
    );

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IVentasService, VentasService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddAuthorization();

var key = Encoding.ASCII.GetBytes("6B29FC40-CA47-1067-B31D-00DD010662DA"); 
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "your_issuer",
        ValidAudience = "your_audience",
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader()
     //.AllowCredentials()
     );

app.UseAuthorization();
app.MapControllers();


app.Run();

