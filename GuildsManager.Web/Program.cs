using GuildsManager.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string conn = builder.Configuration.GetConnectionString("Local");

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<GuildsDbContext>(options => { options.UseSqlServer(conn); });

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
  app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/api/factions", async (GuildsDbContext context) =>
{
  List<Faction> factions = await context
    .Factions
    .ToListAsync();

  return Results.Ok(factions);
});

app.MapGet("/api/model-cards", async ([FromQuery] short factionId, GuildsDbContext context) =>
{
  List<ModelCard> modelCards = await context
    .ModelCards
    .Where(x => x.FactionId == factionId)
    .ToListAsync();

  return Results.Ok(modelCards);
});

app.Run();