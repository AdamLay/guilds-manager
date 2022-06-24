using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.Pages.Abilities
{
	public class CreateModel : PageModel
	{
		private readonly GuildsDbContext _context;

		public CreateModel(GuildsDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> OnGet(short id)
		{
			var modelCard = await _context.ModelCards.FindAsync(id);

			if (modelCard is null)
				return NotFound("Model card not found for id: " + id);

			return Page();
		}

		[BindProperty]
		public Ability Ability { get; set; } = default!;


		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Abilities == null || Ability == null)
			{
				return Page();
			}

			_context.Abilities.Add(Ability);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
