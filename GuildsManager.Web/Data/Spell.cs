using System.ComponentModel.DataAnnotations;

namespace GuildsManager.Web.Data;

public class Spell
{
  [Key]
  public short Id { get; set; }
  
  public SpellSchool School { get; set; }
  
  [MaxLength(32)]
  public string Name { get; set; }
  
  public byte Rank { get; set; }
  public byte? Roll { get; set; }
  public bool AoE { get; set; }
  public Stat? Vs { get; set; }
  public byte? Range { get; set; }
  public bool Self { get; set; }
  public bool InVision { get; set; }
  
  [MaxLength(1024)]
  public string Effect { get; set; }
}

public enum SpellSchool
{
  Elemental,
  Animancy,
  Druidcraft,
  Necromancy
}