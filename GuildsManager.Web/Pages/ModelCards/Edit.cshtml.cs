using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuildsManager.Web.Data;
using GuildsManager.Web.ViewModels.ModelCards;

namespace GuildsManager.Web.Pages.ModelCards
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

    [BindProperty] public ModelCardViewModel ViewModel { get; set; } = default!;

    public List<Ability> Abilities { get; set; }
    public List<Attack> Attacks { get; set; }

    private async Task SetViewData()
    {
      ViewData["FactionId"] = new SelectList(_context.Factions, "Id", "Name");

      Attacks = await _context
        .Attacks
        .Where(x => x.CardId == ViewModel.Id)
        .ToListAsync();

      Abilities = await _context
        .Abilities
        .Where(x => x.CardId == ViewModel.Id)
        .ToListAsync();
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null || _context.ModelCards == null)
        return NotFound();

      ModelCard? entity = await _context
        .ModelCards
        .FirstOrDefaultAsync(m => m.Id == id);

      if (entity == null)
        return NotFound();

      ViewModel = _mapper.Map<ModelCardViewModel>(entity);

      await SetViewData();

      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        await SetViewData();
        return Page();
      }

      short id = ViewModel.Id.Value;

      ModelCard? original = await _context
        .ModelCards
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.Id == id);

      if (original is null)
        return NotFound();

      ModelCard entity = _mapper.Map(ViewModel, original);

      _context.Attach(entity).State = EntityState.Modified;

      await _context.SaveChangesAsync();

      return RedirectToPage("/Factions/Edit", new {id = entity.FactionId});
    }
  }
}