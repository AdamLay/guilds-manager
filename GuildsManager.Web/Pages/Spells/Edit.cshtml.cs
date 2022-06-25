using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildsManager.Web.Data;
using GuildsManager.Web.ViewModels.Spells;

namespace GuildsManager.Web.Pages.Spells
{
  public class EditModel : PageModel
  {
    private readonly GuildsDbContext _context;
    private readonly IMapper _mapper;

    public EditModel(GuildsDbContext context, IMapper mapper)
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

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      Spell? original = await _context
        .Spells
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.Id == ViewModel.Id.Value);

      if (original is null)
        return NotFound();

      Spell entity = _mapper.Map(ViewModel, original);

      _context.Attach(entity).State = EntityState.Modified;

      await _context.SaveChangesAsync();
      
      return RedirectToPage("./Index");
    }
  }
}