namespace GuildsManager.Web.Responses;

public class AbilityResponse
{
  public short Id { get; set; }
  public short CardId { get; set; }
  public string Name { get; set; }
  public string Text { get; set; }

  public bool Passive { get; set; }
  public bool Fatigue { get; set; }
  public bool Torment { get; set; }
}