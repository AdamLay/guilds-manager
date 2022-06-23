using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GuildsManager.Web.Data;
using GuildsManager.Web.ViewModels.ModelCards;

namespace GuildsManager.Web.Pages.ModelCards
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

    [BindProperty]
    public ModelCardViewModel ViewModel { get; set; } = new()
    {
      Slots = 1
    };
    
    private void SetViewData()
    {
      ViewData["FactionId"] = new SelectList(_context.Factions, "Id", "Name");
    }
    
    public IActionResult OnGet()
    {
      SetViewData();
      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid || _context.ModelCards == null || ViewModel == null)
      {
        SetViewData();
        return Page();
      }

      var entity = _mapper.Map<ModelCard>(ViewModel);

      _context.ModelCards.Add(entity);
      
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}