namespace GuildsManager.Web.Services;

public class UserService
{
  public string HashPassword(string password)
  {
    return BCrypt.Net.BCrypt.HashPassword(password);
  }

  public bool ComparePasswords(string input, string passwordHash)
  {
    return BCrypt.Net.BCrypt.Verify(input, passwordHash);
  }
}