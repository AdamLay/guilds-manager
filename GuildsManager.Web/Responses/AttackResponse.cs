using GuildsManager.Web.Data;

namespace GuildsManager.Web.Responses;

public class AttackResponse
{
  public short? Id { get; set; }
  public short CardId { get; set; }
  public string Name { get; set; }

  public byte Attacks { get; set; }
  public bool AoE { get; set; }
  public byte? MinRange { get; set; }
  public byte Range { get; set; }
  public byte? Arc { get; set; }
  public Element? Element { get; set; }
}