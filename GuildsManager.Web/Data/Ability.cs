using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GuildsManager.Web.Data;

public class Ability
{
  [Key]
  public short Id { get; set; }
  
  public short CardId { get; set; }
  [JsonIgnore]
  public ModelCard Card { get; set; }

  [MaxLength(64)]
  public string Name { get; set; }
  
  [MaxLength(512)]
  public string Text { get; set; }
  
  public bool Passive { get; set; }
  public bool Fatigue { get; set; }
  public bool Torment { get; set; }
}