using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.Pages.Attacks
{
  public class DeleteModel : PageModel
  {
    private readonly GuildsManager.Web.Data.GuildsDbContext _context;

    public DeleteModel(GuildsManager.Web.Data.GuildsDbContext context)
    {
      _context = context;
    }

    [BindProperty] public Attack Attack { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(short? id)
    {
      if (id == null || _context.Attacks == null)
      {
        return NotFound();
      }

      var attack = await _context.Attacks.FirstOrDefaultAsync(m => m.Id == id);

      if (attack == null)
      {
        return NotFound();
      }

      Attack = attack;
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(short? id)
    {
      if (id == null || _context.Attacks == null)
      {
        return NotFound();
      }

      var attack = await _context.Attacks.FindAsync(id);

      if (attack == null) return NotFound();

      short cardId = attack.CardId;
      Attack = attack;
      _context.Attacks.Remove(Attack);
      await _context.SaveChangesAsync();

      return RedirectToPage("/ModelCards/Edit", new {id = cardId});
    }
  }
}