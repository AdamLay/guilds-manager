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
    public class IndexModel : PageModel
    {
        private readonly GuildsManager.Web.Data.GuildsDbContext _context;

        public IndexModel(GuildsManager.Web.Data.GuildsDbContext context)
        {
            _context = context;
        }

        public IList<Attack> Attack { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Attacks != null)
            {
                Attack = await _context.Attacks.ToListAsync();
            }
        }
    }
}
