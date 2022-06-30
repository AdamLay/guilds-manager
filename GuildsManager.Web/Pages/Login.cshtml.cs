using System.Security.Claims;
using GuildsManager.Web.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuildsManager.Web.Pages;

public class Login : PageModel
{
  private readonly GuildsDbContext _context;

  public Login(GuildsDbContext context)
  {
    _context = context;
  }

  [BindProperty] public string Email { get; set; }
  [BindProperty] public string Password { get; set; }
  
  public string Message { get; set; }

  public async Task<IActionResult> OnPostAsync()
  {
    User? user = await _context.Users.FindAsync(Email);
    if (user is null)
    {
      Message = "Invalid username or password.";
      return Page();
    }

    bool valid = BCrypt.Net.BCrypt.Verify(Password, user.Password);

    if (!valid)
    {
      Message = "Invalid username or password.";
      return Page();
    }

    await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(new[]
    {
      new Claim(ClaimTypes.Email, user.Email)
    })));
    
    return Redirect("/Factions");
  }
}