using GuildsManager.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuildsManager.Web.Pages;

public class Register : PageModel
{
  private readonly GuildsDbContext _context;

  public Register(GuildsDbContext context)
  {
    _context = context;
  }

  [BindProperty] public string Email { get; set; }
  [BindProperty] public string Password { get; set; }

  public IActionResult OnGet => Page();

  public async Task<IActionResult> OnPostAsync()
  {
    if (!ModelState.IsValid)
      return Page();

    _context.Users.Add(new User
    {
      Email = Email,
      Password = BCrypt.Net.BCrypt.EnhancedHashPassword(Password)
    });

    await _context.SaveChangesAsync();

    return Redirect("/Factions");
  }
}