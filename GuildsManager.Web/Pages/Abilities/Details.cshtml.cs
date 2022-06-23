using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.Pages.Abilities
{
    public class DetailsModel : PageModel
    {
        private readonly GuildsManager.Web.Data.GuildsDbContext _context;

        public DetailsModel(GuildsManager.Web.Data.GuildsDbContext context)
        {
            _context = context;
        }

      public Ability Ability { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null || _context.Abilities == null)
            {
                return NotFound();
            }

            var ability = await _context.Abilities.FirstOrDefaultAsync(m => m.Id == id);
            if (ability == null)
            {
                return NotFound();
            }
            else 
            {
                Ability = ability;
            }
            return Page();
        }
    }
}
