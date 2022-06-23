using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.Pages.Attacks
{
    public class EditModel : PageModel
    {
        private readonly GuildsManager.Web.Data.GuildsDbContext _context;

        public EditModel(GuildsManager.Web.Data.GuildsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Attack Attack { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null || _context.Attacks == null)
            {
                return NotFound();
            }

            var attack =  await _context.Attacks.FirstOrDefaultAsync(m => m.Id == id);
            if (attack == null)
            {
                return NotFound();
            }
            Attack = attack;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Attack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttackExists(Attack.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AttackExists(short id)
        {
          return (_context.Attacks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
