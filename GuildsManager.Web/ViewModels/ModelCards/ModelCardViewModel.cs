using System.ComponentModel.DataAnnotations;

namespace GuildsManager.Web.ViewModels.ModelCards;

public class ModelCardViewModel
{
  public short? Id { get; set; }
  
  public short FactionId { get; set; }
  
  [Required]
  [MaxLength(64)]
  public string Name { get; set; }
  [MaxLength(128)]
  public string Keywords { get; set; }
  public byte Slots { get; set; }
  public byte UnitNumber { get; set; }
  
  public byte Might { get; set; }
  public bool Healing { get; set; }
  
  public byte Dex { get; set; }
  public bool IgnoreDifficultTerrain { get; set; }
  public bool Levitating { get; set; }
  
  public byte Will { get; set; }
  
  public byte Def { get; set; }
  public bool Shield { get; set; }
}