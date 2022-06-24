namespace GuildsManager.Web.Responses;

public class ModelCardResponse
{
  public short Id { get; set; }
  public short FactionId { get; set; }
  public string Name { get; set; }
  public string Keywords { get; set; }
  public byte Slots { get; set; }
  public byte UnitNumber { get; set; }
  
  public byte Might { get; set; }
  public bool Healing { get; set; }
  
  public byte Dex { get; set; }
  public bool IgnoreDifficultTerrain { get; set; }
  public bool Levitating { get; set; }
  
  public byte Def { get; set; }
  public bool Shield { get; set; }
  
  public byte Will { get; set; }
  
  public byte HeroicWounds { get; set; }
  
  public string RW { get; set; }
  
  public AbilityResponse[] Abilities { get; set; }
  public AttackResponse[] Attacks { get; set; }
}