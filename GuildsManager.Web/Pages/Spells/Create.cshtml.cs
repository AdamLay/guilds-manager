using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GuildsManager.Web.Data;
using GuildsManager.Web.ViewModels.Spells;

namespace GuildsManager.Web.Pages.Spells
{
  public class CreateModel : PageModel
  {
    private readonly GuildsDbContext _context;
    private readonly IMapper _mapper;

    public CreateModel(GuildsDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public IActionResult OnGet()
    {
      return Page();
    }

    [BindProperty] public SpellViewModel ViewModel { get; set; } = new() {Rank = 1};


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid || _context.Spells == null || ViewModel == null)
      {
        return Page();
      }

      var entity = _mapper.Map<Spell>(ViewModel);

      _context.Spells.Add(entity);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}