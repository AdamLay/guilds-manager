using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildsManager.Web.Data;
using GuildsManager.Web.ViewModels.Spells;

namespace GuildsManager.Web.Pages.Spells
{
  public class DeleteModel : PageModel
  {
    private readonly GuildsDbContext _context;
    private readonly IMapper _mapper;

    public DeleteModel(GuildsDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [BindProperty] public SpellViewModel ViewModel { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(short? id)
    {
      if (id == null || _context.Spells == null)
      {
        return NotFound();
      }

      var entity = await _context.Spells.FirstOrDefaultAsync(m => m.Id == id);

      if (entity == null)
      {
        return NotFound();
      }

      ViewModel = _mapper.Map<SpellViewModel>(entity);
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(short? id)
    {
      if (id == null || _context.Spells == null)
      {
        return NotFound();
      }

      var entity = await _context.Spells.FindAsync(id);
      if (entity == null) return RedirectToPage("./Index");
      _context.Spells.Remove(entity);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}