using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.Pages.Spells
{
  public class IndexModel : PageModel
  {
    private readonly GuildsDbContext _context;

    public IndexModel(GuildsDbContext context)
    {
      _context = context;
    }

    public IList<Spell> Spells { get; set; } = default!;

    public async Task OnGetAsync()
    {
      if (_context.Spells != null)
      {
        Spells = await _context.Spells.ToListAsync();
      }
    }
  }
}