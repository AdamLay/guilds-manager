using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.Pages.ModelCards
{
    public class DeleteModel : PageModel
    {
        private readonly GuildsManager.Web.Data.GuildsDbContext _context;

        public DeleteModel(GuildsManager.Web.Data.GuildsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ModelCard ModelCard { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ModelCards == null)
            {
                return NotFound();
            }

            var modelcard = await _context.ModelCards.FirstOrDefaultAsync(m => m.Id == id);

            if (modelcard == null)
            {
                return NotFound();
            }
            else 
            {
                ModelCard = modelcard;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ModelCards == null)
            {
                return NotFound();
            }
            var modelcard = await _context.ModelCards.FindAsync(id);

            if (modelcard != null)
            {
                ModelCard = modelcard;
                _context.ModelCards.Remove(ModelCard);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
