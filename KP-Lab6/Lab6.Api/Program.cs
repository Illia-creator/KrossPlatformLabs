using Lab6.Api.Dal;
using Lab6.Api.DbSetups.Options;
using Lab6.Api.DbSetups.Setups;
using Lab6.Api.Entities.Dtos;
using Lab6.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<LabService>();

builder.Services.ConfigureOptions<PostgresOptionsSetup>();
builder.Services.ConfigureOptions<SqlLiteOptionsSetup>();
builder.Services.ConfigureOptions<MsSqlOptionsSetup>();
builder.Services.ConfigureOptions<InMemoryOptionsSetup>();

builder.Services.AddDbContext<LabDbContext>((serviceProvider, dbContextOptionsBuilder) =>
{
    var postgresDatabaseOptions = serviceProvider.GetService<IOptions<PostgresOptions>>()!.Value;
    var sqlLiteDatabaseOptions = serviceProvider.GetService<IOptions<SqlLiteOptions>>()!.Value;
    var msSqlDatabaseOptions = serviceProvider.GetService<IOptions<MsSqlOptions>>()!.Value;
    var memoryDatabaseOptions = serviceProvider.GetService<IOptions<InMemoryOptions>>()!.Value;

    if (postgresDatabaseOptions is not null && postgresDatabaseOptions.IsEnable)
    {
        dbContextOptionsBuilder.UseNpgsql(postgresDatabaseOptions.PostgresConnection);
    }

    if (sqlLiteDatabaseOptions is not null && sqlLiteDatabaseOptions.IsEnable)
    {
        dbContextOptionsBuilder.UseSqlite(sqlLiteDatabaseOptions.SqlLiteConnection);
    }

    if (msSqlDatabaseOptions is not null && msSqlDatabaseOptions.IsEnable)
    {
        dbContextOptionsBuilder.UseSqlServer(msSqlDatabaseOptions.MsSqlConnectionString, sqlServerAction =>
        {
            sqlServerAction.EnableRetryOnFailure(msSqlDatabaseOptions.MaxRetryCount);

            sqlServerAction.CommandTimeout(msSqlDatabaseOptions.CommandTimeout);
        });

        dbContextOptionsBuilder.EnableDetailedErrors(msSqlDatabaseOptions!.EnableDetailedErrors);

        dbContextOptionsBuilder.EnableSensitiveDataLogging(msSqlDatabaseOptions.EnableSensitiveLogging);
    }

    if (memoryDatabaseOptions is not null && memoryDatabaseOptions.IsEnable)
    {
        dbContextOptionsBuilder.UseInMemoryDatabase("InMemoryDb");
    }
});
builder.Services.AddScoped<LabDbInitializer>();

var jwtOptions = builder.Configuration.BindOptions<JwtOptions>("Security");

builder.Services.AddSingleton(jwtOptions);

builder.Services.AddTime();


builder.Services.AddScoped<IJwtTokenProvider, JwtTokenProvider>();
builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextStorage, HttpContextStorage>();
builder.Services.AddScoped<IPasswordManager, PasswordManager>();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(jwt =>
    {
        var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));

        jwt.SaveToken = true;

        jwt.TokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = issuerSigningKey,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            ValidateIssuer = true,
            ValidateAudience = true
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

app.Run();
