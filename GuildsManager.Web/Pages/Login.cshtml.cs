using System.Security.Claims;
using GuildsManager.Web.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuildsManager.Web.Pages;

[AllowAnonymous]
public class Login : PageModel
{
  private readonly GuildsDbContext _context;

  public Login(GuildsDbContext context)
  {
    _context = context;
  }

  [BindProperty] public string Email { get; set; }
  [BindProperty] public string Password { get; set; }
  [BindProperty] public bool Remember { get; set; }
  
  public string Message { get; set; }

  public async Task<IActionResult> OnPostAsync()
  {
    User? user = await _context.Users.FindAsync(Email);
    if (user is null)
    {
      Message = "Invalid username or password.";
      return Page();
    }

    bool valid = BCrypt.Net.BCrypt.EnhancedVerify(Password, user.Password);

    if (!valid)
    {
      Message = "Invalid username or password.";
      return Page();
    }
    
    var identity = new ClaimsIdentity(new[]
    {
      new Claim(ClaimTypes.Email, user.Email)
    }, CookieAuthenticationDefaults.AuthenticationScheme);
    
    var principal = new ClaimsPrincipal(identity);

    await HttpContext.SignInAsync(principal);
    
    return Redirect("/Factions");
  }
}