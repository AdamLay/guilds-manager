using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.Pages.Attacks
{
    public class DetailsModel : PageModel
    {
        private readonly GuildsManager.Web.Data.GuildsDbContext _context;

        public DetailsModel(GuildsManager.Web.Data.GuildsDbContext context)
        {
            _context = context;
        }

      public Attack Attack { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null || _context.Attacks == null)
            {
                return NotFound();
            }

            var attack = await _context.Attacks.FirstOrDefaultAsync(m => m.Id == id);
            if (attack == null)
            {
                return NotFound();
            }
            else 
            {
                Attack = attack;
            }
            return Page();
        }
    }
}
