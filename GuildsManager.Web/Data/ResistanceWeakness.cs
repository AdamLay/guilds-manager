using System.ComponentModel.DataAnnotations;

namespace GuildsManager.Web.Data;

public class ResistanceWeakness
{
  [Key]
  public short Id { get; set; }
  
  public short CardId { get; set; }
  public ModelCard Card { get; set; }
  
  public Element Element { get; set; }
  public ElementEffect Effect { get; set; }
}

public enum ElementEffect { Resistance, Weakness, Immunity }