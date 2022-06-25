using System.ComponentModel.DataAnnotations;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.ViewModels.Spells;

public class SpellViewModel
{
  public short? Id { get; set; }
  
  [Required]
  public SpellSchool School { get; set; }
  
  [Required]
  [MaxLength(32)]
  public string Name { get; set; }
  
  [Required]
  public byte Rank { get; set; }
  public byte? Roll { get; set; }
  public bool AoE { get; set; }
  public Stat? Vs { get; set; }
  public byte? Range { get; set; }
  public bool Self { get; set; }
  public bool InVision { get; set; }
  
  [Required]
  [MaxLength(1024)]
  public string Effect { get; set; }
}