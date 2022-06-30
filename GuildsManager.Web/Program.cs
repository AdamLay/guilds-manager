using AutoMapper;
using GuildsManager.Web.Data;
using GuildsManager.Web.Responses;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string conn = builder.Configuration.GetConnectionString("Heroku"); //"Local");

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<GuildsDbContext>(options =>
{
  //options.UseSqlServer(conn);
  //options.UseInMemoryDatabase("Guilds");
  options.UseNpgsql(conn);
});

builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(policy =>
  {
    policy.AllowAnyOrigin();
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
  });
});

builder.Services
  .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
  .AddCookie(options =>
  {
    options.LoginPath = "/login";
  });

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  //app.UseHsts();
  //app.UseHttpsRedirection();

  app.Urls.Add("http://*:" + Environment.GetEnvironmentVariable("PORT"));
}
else
{
  app.Urls.Add("http://0.0.0.0:8080");
  app.Urls.Add("http://[::]:8080");
}

foreach (var url in app.Urls)
{
  Console.WriteLine("URL: " + url);
}

app.UseStaticFiles();

app.UseCors();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages().RequireAuthorization();

app.MapGet("/api/factions", async (GuildsDbContext context) =>
{
  List<Faction> factions = await context
    .Factions
    .ToListAsync();

  return Results.Ok(factions);
});

app.MapGet("/api/spells", async (GuildsDbContext context) =>
{
  List<Spell> spells = await context
    .Spells
    .ToListAsync();

  return Results.Ok(spells);
});

app.MapGet("/api/model-cards", async ([FromQuery] short? factionId,
  GuildsDbContext context, IMapper mapper) =>
{
  var modelCards = context
    .ModelCards
    .Include(x => x.Attacks)
    .Include(x => x.Abilities);

  var results = factionId.HasValue
    ? modelCards.Where(x => x.FactionId == factionId).ToList()
    : modelCards.ToList();

  return Results.Ok(results.Select(x => mapper.Map<ModelCardResponse>(x)));
});

app.Run();