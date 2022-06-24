using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildsManager.Web.Data;
using GuildsManager.Web.ViewModels.Attacks;

namespace GuildsManager.Web.Pages.Attacks
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

    [BindProperty] public AttackViewModel ViewModel { get; set; } = new();
    public ModelCard? ModelCard { get; set; }

    public async Task<IActionResult> OnGetAsync(short? id)
    {
      if (id == null || _context.Attacks == null)
      {
        return NotFound();
      }

      Attack? entity = await _context.Attacks.FirstOrDefaultAsync(m => m.Id == id);
      if (entity == null)
      {
        return NotFound();
      }

      ModelCard = await _context.ModelCards.FindAsync(entity.CardId);

      ViewModel = _mapper.Map<AttackViewModel>(entity);

      return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      Attack? original = await _context
        .Attacks
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.Id == ViewModel.Id.Value);

      if (original is null)
        return NotFound();

      Attack entity = _mapper.Map(ViewModel, original);

      _context.Attach(entity).State = EntityState.Modified;

      await _context.SaveChangesAsync();

      return RedirectToPage("/ModelCards/Edit", new { id = ViewModel.CardId });
    }
  }
}