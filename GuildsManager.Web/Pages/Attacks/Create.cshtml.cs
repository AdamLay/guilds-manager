using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.Pages.Attacks
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
        public Attack Attack { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Attacks == null || Attack == null)
            {
                return Page();
            }

            _context.Attacks.Add(Attack);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
