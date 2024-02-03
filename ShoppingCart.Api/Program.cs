using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using ShoppingCart.Api.Middlewares;
using ShoppingCart.Data.Contexts;
using ShoppingCart.Services.Mappings;
using ShoppingCart.Services.Auth;
using ShoppingCart.Services.Token;
using System.Text;
using ShoppingCart.Services.Items;
using ShoppingCart.Services.Categories;
using ShoppingCart.Services.Permissions;
using ShoppingCart.Services.CartItems;

string localhostPolicy = "localhost_policy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
{
    options.SwaggerDoc(builder.Configuration["ApiInfo:Version"], new OpenApiInfo()
    {
        Title = builder.Configuration["ApiInfo:Title"],
        Version = builder.Configuration["ApiInfo:Version"]
    });

    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });
});

// Add Auth Db Context
builder.Services.AddDbContext<AuthDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnectionString"));
});

// Add Shopping Cart Db Context
builder.Services.AddDbContext<ShoppingCartDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShoppingCartConnectionString"));
});

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IItemsService, ItemsService>();
builder.Services.AddTransient<ICategoriesService, CategoriesService>();
builder.Services.AddTransient<IPermissionsService, PermissionsService>();
builder.Services.AddTransient<ICartItemsService, CartItemsService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

// Add Cors 
builder.Services.AddCors(options =>
{
    options.AddPolicy(localhostPolicy, p =>
    {
        p.WithOrigins("localhost", "localhost:4200", "http://localhost:4200");
        p.WithHeaders("*");
        p.WithMethods("*");
    });
});

// Add services to the container.
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/ShoppingCart_Api_Log.txt", rollingInterval: RollingInterval.Infinite)
    .MinimumLevel.Verbose()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add Identity
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("ShoppingCartTokenProvider")
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

// Password Configuration
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;    
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;
});

// JWT Token Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
    });

// Building app
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

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(policyName: localhostPolicy);

app.Run();
