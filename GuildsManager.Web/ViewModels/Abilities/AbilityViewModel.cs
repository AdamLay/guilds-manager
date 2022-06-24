using System.ComponentModel.DataAnnotations;

namespace GuildsManager.Web.ViewModels.Abilities
{
	public class AbilityViewModel
	{
    public short? Id { get; set; }
    public short CardId { get; set; }

		[Required]
    [MaxLength(32)]
    public string Name { get; set; }

    [Required]
    [MaxLength(512)]
    public string Text { get; set; }

    public bool Passive { get; set; }
    public bool Fatigue { get; set; }
    public bool Torment { get; set; }
  }
}
