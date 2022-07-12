using System.Text;
using System.Text.Json.Serialization;
using Application.Services;
using Domain.Interfaces;
using Domain.Utils;
using Infra.Data;
using Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(p =>
    p.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = Encoding.ASCII.GetBytes(Settings.Secret);

builder.Services.AddAuthentication(p =>
    {
        p.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        p.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(p =>
    {
        p.RequireHttpsMetadata = false;
        p.SaveToken = true;
        p.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        }; });

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddTransient<IBankTransactionRepository, BankTransactionRepository>();
builder.Services.AddTransient<ICardRepository, CardRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddScoped<IBankTransactionService, BankTransactionService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ISignInService, SignInService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
