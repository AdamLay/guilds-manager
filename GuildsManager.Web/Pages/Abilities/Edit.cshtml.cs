using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.Pages.Abilities
{
    public class EditModel : PageModel
    {
        private readonly GuildsManager.Web.Data.GuildsDbContext _context;

        public EditModel(GuildsManager.Web.Data.GuildsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ability Ability { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null || _context.Abilities == null)
            {
                return NotFound();
            }

            var ability =  await _context.Abilities.FirstOrDefaultAsync(m => m.Id == id);
            if (ability == null)
            {
                return NotFound();
            }
            Ability = ability;
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

            _context.Attach(Ability).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbilityExists(Ability.Id))
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

        private bool AbilityExists(short id)
        {
          return (_context.Abilities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
