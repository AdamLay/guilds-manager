using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.Pages.Factions
{
    public class CreateModel : PageModel
    {
        private readonly GuildsManager.Web.Data.GuildsDbContext _context;

        public CreateModel(GuildsManager.Web.Data.GuildsDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Faction Faction { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Factions == null || Faction == null)
            {
                return Page();
            }

            _context.Factions.Add(Faction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
