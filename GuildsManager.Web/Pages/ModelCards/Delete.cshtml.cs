using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.Pages.ModelCards
{
  public class DeleteModel : PageModel
  {
    private readonly GuildsDbContext _context;

    public DeleteModel(GuildsDbContext context)
    {
      _context = context;
    }

    [BindProperty] public ModelCard ModelCard { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.ModelCards == null)
      {
        return NotFound();
      }

      var entity = await _context
        .ModelCards
        .Include(x => x.Faction)
        .FirstOrDefaultAsync(m => m.Id == id);

      if (entity == null)
      {
        return NotFound();
      }

      ModelCard = entity;

      return Page();
    }

    public async Task<IActionResult> OnPostAsync(short? id)
    {
      if (id == null || _context.ModelCards == null)
      {
        return NotFound();
      }

      var entity = await _context.ModelCards.FindAsync(id);

      if (entity == null) return NotFound();
      short factionId = entity.FactionId;
      _context.ModelCards.Remove(entity);
      await _context.SaveChangesAsync();

      return RedirectToPage("/Factions/Edit", new { id = factionId });
    }
  }
}