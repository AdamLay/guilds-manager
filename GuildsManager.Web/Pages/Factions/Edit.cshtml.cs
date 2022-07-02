using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.Pages.Factions
{
  public class EditModel : PageModel
  {
    private readonly GuildsDbContext _context;

    public EditModel(GuildsDbContext context)
    {
      _context = context;
    }

    [BindProperty] public Faction Faction { get; set; } = default!;

    public List<ModelCard> ModelCards { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(short? id)
    {
      if (id == null || _context.Factions == null)
      {
        return NotFound();
      }

      var faction = await _context.Factions.FirstOrDefaultAsync(m => m.Id == id);
      if (faction == null)
      {
        return NotFound();
      }

      ModelCards = await _context.ModelCards
        .Where(x => x.FactionId == id)
        .Include(x => x.Attacks)
        .Include(x => x.Abilities)
        .ToListAsync();

      Faction = faction;
      return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Attach(Faction).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!FactionExists(Faction.Id))
        {
          return NotFound();
        }

        throw;
      }

      return RedirectToPage("./Index");
    }

    private bool FactionExists(short id)
    {
      return (_context.Factions?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}