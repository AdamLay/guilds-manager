using System.ComponentModel.DataAnnotations;

namespace GuildsManager.Web.Data;

public class Attack
{
  [Key]
  public short Id { get; set; }
  
  public short CardId { get; set; }
  public ModelCard Card { get; set; }
  
  [MaxLength(64)]
  public string Name { get; set; }
  public byte Attacks { get; set; }
  public bool AoE { get; set; }
  public byte? MinRange { get; set; }
  public byte Range { get; set; }
  public byte? Arc { get; set; }
  public Element? Element { get; set; }
}