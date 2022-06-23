using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.Pages.ModelCards
{
  public class IndexModel : PageModel
  {
    private readonly GuildsManager.Web.Data.GuildsDbContext _context;

    public IndexModel(GuildsManager.Web.Data.GuildsDbContext context)
    {
      _context = context;
    }

    public List<ModelCard> ModelCard { get; set; } = default!;

    public async Task OnGetAsync()
    {
      if (_context.ModelCards != null)
      {
        ModelCard = await _context.ModelCards
          .Include(m => m.Faction).ToListAsync();
      }
    }
  }
}