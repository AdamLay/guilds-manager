using System.ComponentModel.DataAnnotations;

namespace GuildsManager.Web.Data;

public class User
{
  [Key, MaxLength(128)]
  public string Email { get; set; }
  [MaxLength(128)]
  public string Password { get; set; }
}