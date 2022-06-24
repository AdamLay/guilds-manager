using System.ComponentModel.DataAnnotations;
using GuildsManager.Web.Data;

namespace GuildsManager.Web.ViewModels.Attacks
{
	public class AttackViewModel
	{
    public short? Id { get; set; }
    public short CardId { get; set; }

		[Required]
    [MaxLength(32)]
    public string Name { get; set; }

    public byte Attacks { get; set; }
    public bool AoE { get; set; }
    public byte? MinRange { get; set; }
    public byte Range { get; set; }
    public byte? Arc { get; set; }
    public Element? Element { get; set; }
  }
}
