using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Duende.IdentityServer.Models;
using Lab5.Identity.Data;
using Lab5.Identity.Factories;
using Lab5.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<UserDbContext>((serviceProvider, dbContextOptionsBuilder) =>
{
    dbContextOptionsBuilder.UseNpgsql(
        serviceProvider.GetRequiredService<IConfiguration>().GetConnectionString("Identity"),
        NpgsqlOptionsAction);
});


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddClaimsPrincipalFactory<ApplicationUserClaimsPrincipalFactory>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<UserDbContext>();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<ApplicationUser>()
    .AddConfigurationStore(configurationStoreOptions =>
    {
        configurationStoreOptions.ResolveDbContextOptions = ResolveDbContextOptions;
    })
    .AddOperationalStore(operationalStoreOptions =>
    {
        operationalStoreOptions.ResolveDbContextOptions = ResolveDbContextOptions;
    });

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();

app.UseAuthorization();

app.MapRazorPages();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();

    await scope.ServiceProvider.GetRequiredService<UserDbContext>().Database.MigrateAsync();
    await scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>().Database.MigrateAsync();
    await scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.MigrateAsync();

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    if (await userManager.FindByNameAsync("Illia") == null)
    {
        await userManager.CreateAsync(
            new ApplicationUser
            {
                UserName = "Illia",
                Email = "sie29092002@gmail.com",
                FullName = "Syniavskyi Illia"
            }, "Pass?8989");
    }

    var configurationDbContext = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

    if (!await configurationDbContext.ApiResources.AnyAsync())
    {
        await configurationDbContext.ApiResources.AddAsync(new ApiResource
        {
            Name = "1e3b8a0c-4f5d-45a2-b8c9-8a17c4e2d901",
            DisplayName = "API",
            Scopes = new List<string> { "https://www.illia-syniavskyi.com/api" }
        }.ToEntity());


        await configurationDbContext.SaveChangesAsync();
    }

    if (!await configurationDbContext.ApiScopes.AnyAsync())
    {
        await configurationDbContext.ApiScopes.AddAsync(new ApiScope
        {
            Name = "https://www.illia-syniavskyi.com/api",
            DisplayName = "API"
        }.ToEntity());

        await configurationDbContext.SaveChangesAsync();
    }

    if (!await configurationDbContext.Clients.AnyAsync())
    {
        await configurationDbContext.Clients.AddRangeAsync(
            new Client
            {
                ClientId = "78b65a7f-5d4d-48fe-81cd-1c211928c3d7",
                ClientSecrets = new List<Secret> { new("secret".Sha512()) },
                ClientName = "Web Application",
                AllowedGrantTypes = GrantTypes.Code,
                AllowedScopes = new List<string> { "openid", "profile", "email", "https://www.illia-syniavskyi.com/api" },
                RedirectUris = new List<string> { "https://localhost:7002/signin-oidc" },
                PostLogoutRedirectUris = new List<string> { "https://localhost:7002/signout-callback-oidc" }
            }.ToEntity());

        await configurationDbContext.SaveChangesAsync();
    }

    if (!await configurationDbContext.IdentityResources.AnyAsync())
    {
        await configurationDbContext.IdentityResources.AddRangeAsync(
            new IdentityResources.OpenId().ToEntity(),
            new IdentityResources.Profile().ToEntity(),
            new IdentityResources.Email().ToEntity());

        await configurationDbContext.SaveChangesAsync();
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.Run();

void NpgsqlOptionsAction(NpgsqlDbContextOptionsBuilder npgsqlDbContextOptionsBuilder)
{
    npgsqlDbContextOptionsBuilder.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
}

void ResolveDbContextOptions(IServiceProvider serviceProvider, DbContextOptionsBuilder dbContextOptionsBuilder)
{
    dbContextOptionsBuilder.UseNpgsql(serviceProvider.GetRequiredService<IConfiguration>()
            .GetConnectionString("IdentityServer"), NpgsqlOptionsAction);
}  