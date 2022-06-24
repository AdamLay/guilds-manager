using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GuildsManager.Web.Data;
using GuildsManager.Web.ViewModels.Abilities;

namespace GuildsManager.Web.Pages.Abilities
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
		public AbilityViewModel ViewModel { get; set; } = new();
		public ModelCard? ModelCard { get; set; }
		
		public async Task<IActionResult> OnGet(short cardId)
		{
			ModelCard = await _context.ModelCards.FindAsync(cardId);

			if (ModelCard is null)
				return NotFound("Model card not found for id: " + cardId);

			ViewModel.CardId = cardId;

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Abilities == null || ViewModel == null)
			{
				return Page();
			}

			var entity = _mapper.Map<Ability>(ViewModel);

			_context.Abilities.Add(entity);
			
			await _context.SaveChangesAsync();

			return RedirectToPage("/ModelCards/Edit", new { id = ViewModel.CardId });
		}
	}
}
