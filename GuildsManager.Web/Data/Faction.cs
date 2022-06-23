using System.ComponentModel.DataAnnotations;

namespace GuildsManager.Web.Data;

public class Faction
{
  [Key]
  public short Id { get; set; }
  
  [MaxLength(64)]
  public string Name { get; set; }
  
  public Forces Force { get; set; }
}