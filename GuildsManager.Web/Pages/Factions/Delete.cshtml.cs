using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.Pages.Factions
{
    public class DeleteModel : PageModel
    {
        private readonly GuildsManager.Web.Data.GuildsDbContext _context;

        public DeleteModel(GuildsManager.Web.Data.GuildsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Faction Faction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null || _context.Factions == null)
            {
                return NotFound();
            }

            var faction = await _context.Factions.FirstOrDefaultAsync(m => m.Id == id);

            if (faction == null)
            {
                return NotFound();
            }
            else 
            {
                Faction = faction;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(short? id)
        {
            if (id == null || _context.Factions == null)
            {
                return NotFound();
            }
            var faction = await _context.Factions.FindAsync(id);

            if (faction != null)
            {
                Faction = faction;
                _context.Factions.Remove(Faction);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
