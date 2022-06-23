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
    public class IndexModel : PageModel
    {
        private readonly GuildsManager.Web.Data.GuildsDbContext _context;

        public IndexModel(GuildsManager.Web.Data.GuildsDbContext context)
        {
            _context = context;
        }

        public IList<Ability> Ability { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Abilities != null)
            {
                Ability = await _context.Abilities.ToListAsync();
            }
        }
    }
}
