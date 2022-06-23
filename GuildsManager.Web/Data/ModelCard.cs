using System.ComponentModel.DataAnnotations;

namespace GuildsManager.Web.Data;

public class ModelCard
{
  [Key]
  public int Id { get; set; }
  
  public short FactionId { get; set; }
  public Faction Faction { get; set; }
  
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

  public List<Ability> Abilities { get; set; } = new ();
  public List<Attack> Attacks { get; set; } = new ();
  public List<ResistanceWeakness> ResistancesWeaknesses { get; set; } = new ();

  public bool IsHero => Keywords.Split(",", StringSplitOptions.TrimEntries).Contains("Hero");
}