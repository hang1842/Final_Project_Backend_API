using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;
using Backend_API.Data;
using Stripe;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


//Add a Database link
builder.Services.AddDbContext<PaymentContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("PaymentContext") ?? 
    throw new InvalidOperationException("Connection string 'PaymentContext' not found.")));

var config = builder.Configuration;
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecurerKey"];
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddRouting(options=>options.LowercaseUrls=true);

builder.Services.AddAuthentication(authOption =>
{
    authOption.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOption.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
    authOption.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
 .AddJwtBearer(jwtOption =>
 {
     var signingKeyData = config["JwtSettings:SigningKey"];
     var signingKeyBytes = Encoding.UTF8.GetBytes(signingKeyData!);
     var signingKey = new SymmetricSecurityKey(signingKeyBytes);

     var issuer = config["JwtSettings:Issuer"];
     var audience = config["JwtSettings:Audience"];

     jwtOption.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateAudience = true,
         ValidateIssuer = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = issuer,
         ValidAudience = audience,
         IssuerSigningKey = signingKey
     };
 });

builder.Services.AddAuthorization(authOption => {

    authOption.AddPolicy("IsAdmin", policyOption => {
        // policyOption.RequireClaim("Groups", "admin");
        policyOption.RequireRole("admin");
    });

    authOption.AddPolicy("IsCustomer", policyOption => {
        //policyOption.RequireClaim("Groups", "customer");
        policyOption.RequireRole("customer");
    });

    authOption.AddPolicy("IsMerchant", policyOption =>
    {
        //policyOption.RequireClaim("groups", "manager");
        policyOption.RequireRole("merchant");
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseCors(corsOption =>
   corsOption.AllowAnyHeader()
   .AllowAnyMethod()
   .AllowAnyOrigin());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
