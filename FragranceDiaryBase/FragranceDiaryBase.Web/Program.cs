using FragranceDiaryBase.Shared.Services;
using FragranceDiaryBase.Web.Components;
using FragranceDiaryBase.Web.Services;
using FragranceDiaryBase.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FragranceDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("FragranceDb")));


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add device-specific services used by the FragranceDiaryBase.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var db = services.GetRequiredService<FragranceDbContext>();

    // Apply any pending migrations (optional but nice)
    db.Database.Migrate();

    // Seed initial data if needed
    DbInitializer.Initialize(db);
}
app.MapGet("/api/perfumes", async (FragranceDbContext db) =>
{
    var perfumes = await db.Perfumes
        .Include(p => p.Brand)
        .Include(p => p.Notes).ThenInclude(pn => pn.Note)
        .Include(p => p.Vibes)
        .ToListAsync();

    return Results.Ok(perfumes);
});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(
        typeof(FragranceDiaryBase.Shared._Imports).Assembly);

app.Run();
