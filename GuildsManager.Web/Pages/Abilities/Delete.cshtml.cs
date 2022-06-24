using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.Pages.Abilities
{
  public class DeleteModel : PageModel
  {
    private readonly GuildsDbContext _context;

    public DeleteModel(GuildsDbContext context)
    {
      _context = context;
    }

    [BindProperty] public Ability Ability { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(short? id)
    {
      if (id == null || _context.Abilities == null)
      {
        return NotFound();
      }

      var ability = await _context.Abilities.FirstOrDefaultAsync(m => m.Id == id);
      if (ability == null)
      {
        return NotFound();
      }

      Ability = ability;

      return Page();
    }

    public async Task<IActionResult> OnPostAsync(short? id)
    {
      if (id == null || _context.Abilities == null)
      {
        return NotFound();
      }

      var ability = await _context.Abilities.FindAsync(id);
      if (ability is null)
        return NotFound();

      short cardId = ability.CardId;
      Ability = ability;
      _context.Abilities.Remove(Ability);
      await _context.SaveChangesAsync();
      return RedirectToPage("/ModelCards/Edit", new {id = cardId});
    }
  }
}