using System.ComponentModel.DataAnnotations;

namespace GuildsManager.Web.Data;

public class Ability
{
  [Key]
  public short Id { get; set; }
  
  public short CardId { get; set; }
  public ModelCard Card { get; set; }

  [MaxLength(32)]
  public string Name { get; set; }
  
  [MaxLength(512)]
  public string Text { get; set; }
  
  public bool Passive { get; set; }
  public bool Fatigue { get; set; }
  public bool Torment { get; set; }
}