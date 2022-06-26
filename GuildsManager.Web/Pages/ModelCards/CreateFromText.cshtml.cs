using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GuildsManager.Web.Data;
using GuildsManager.Web.ViewModels.ModelCards;

namespace GuildsManager.Web.Pages.ModelCards
{
  public class CreateFromTextModel : PageModel
  {
    private readonly GuildsDbContext _context;
    private readonly IMapper _mapper;

    public CreateFromTextModel(GuildsDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [BindProperty] public CreateFromTextViewModel ViewModel { get; set; } = new();

    private void SetViewData()
    {
      ViewData["FactionId"] = new SelectList(_context.Factions, "Id", "Name");
    }

    public IActionResult OnGet()
    {
      string factionId = HttpContext.Request.Query["factionId"];
      if (!string.IsNullOrEmpty(factionId))
      {
        ViewModel.FactionId = short.Parse(factionId);
      }

      SetViewData();
      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid || _context.ModelCards == null || ViewModel == null)
      {
        SetViewData();
        return Page();
      }

      foreach (var majorInput in ViewModel.Input.Split("|||"))
      {
        var input = majorInput.Trim().Split(Environment.NewLine);

        var entity = new ModelCard
        {
          FactionId = ViewModel.FactionId,
          Keywords = input[1].Trim(),
          Slots = 1,
          UnitNumber = 1,
          RW = string.Empty
        };

        #region Title & Keywords

        Match titleMatch = new Regex(@"([\w\s]+)(\(([\d\*]+)\))?").Match(input[0]);

        entity.Name = titleMatch.Groups[1].Value.Trim();

        // 3 slots or unit
        if (titleMatch.Groups[3].Success)
        {
          var slotsOrUnitCount = titleMatch.Groups[3].Value;
          if (slotsOrUnitCount.Contains('*'))
          {
            entity.Slots = (byte) slotsOrUnitCount.Length;
          }
          else
          {
            entity.UnitNumber = byte.Parse(slotsOrUnitCount);
          }
        }

        #endregion

        #region Stats

        bool hasHeroicWounds = input[2] == "HW";
        int offset = hasHeroicWounds ? 2 : 0;
        if (hasHeroicWounds)
        {
          entity.HeroicWounds = byte.Parse(input[3]);
        }

        var statNumber = new Regex(@"^(\d+)");
        var might = input[3 + offset];
        entity.Might = byte.Parse(statNumber.Match(might).Groups[1].Value);
        entity.Healing = might.Contains('R');
        var dex = input[5 + offset];
        entity.Dex = byte.Parse(statNumber.Match(dex).Groups[1].Value);
        entity.IgnoreDifficultTerrain = dex.Contains('M');
        entity.Levitating = dex.Contains('L');
        var def = input[7 + offset];
        entity.Def = byte.Parse(statNumber.Match(def).Groups[1].Value);
        entity.Shield = def.Contains('S');
        entity.Will = byte.Parse(input[9 + offset]);

        #endregion

        var attacks = new List<Attack>();
        var abilities = new List<Ability>();
        var majorParts = majorInput.Split(Environment.NewLine + Environment.NewLine);

        for (int i = 1; i < majorParts.Length; i++)
        {
          var majorPart = majorParts[i];
          var weaponMatch =
            new Regex(
                @"(?<name>\D+)(?<atk>\d+)(?<aoe>\sAoE)?\sATK(\s\((?<elem>\w+)\))?(\s(?<arc>\d+)°)?\s(?<range>\d+)-?(?<maxRange>\d+)?")
              .Match(majorPart.Trim()); // TODO
          if (majorPart.StartsWith("R/W"))
          {
            entity.RW = majorPart.Replace("R/W:", string.Empty).Trim('.', ' ');
          }
          else if (weaponMatch.Success)
          {
            var attack = new Attack
            {
              Name = weaponMatch.Groups["name"].Value.Trim(),
              Attacks = byte.Parse(weaponMatch.Groups["atk"].Value),
              AoE = weaponMatch.Groups["aoe"].Success,
              Element = weaponMatch.Groups["elem"].Success
                ? Enum.Parse<Element>(weaponMatch.Groups["elem"].Value)
                : null,
              Arc = weaponMatch.Groups["arc"].Success ? byte.Parse(weaponMatch.Groups["arc"].Value) : null,
              Range = weaponMatch.Groups["maxRange"].Success
                ? byte.Parse(weaponMatch.Groups["maxRange"].Value)
                : byte.Parse(weaponMatch.Groups["range"].Value),
              // If there's a max range, then range is the min range
              MinRange = weaponMatch.Groups["maxRange"].Success ? byte.Parse(weaponMatch.Groups["range"].Value) : null
            };
            attacks.Add(attack);
          }
          else // Ability
          {
            var index = majorPart.IndexOf(Environment.NewLine);
            if (index <= 0)
            {
              
            }
            var title = majorPart.Substring(0, index).Trim();
            var text = majorPart.Substring(index + 1).Trim();
            var abilityTitleMatch =
              new Regex(@"^(?<name>[^\(]+)(?<torment>\s\(T\))?(?<passive>\s\(P\))?(?<fatigue>\s\(F\))?$")
                .Match(title);
            var ability = new Ability
            {
              Name = abilityTitleMatch.Groups["name"].Value,
              Fatigue = abilityTitleMatch.Groups["fatigue"].Success,
              Passive = abilityTitleMatch.Groups["passive"].Success,
              Torment = abilityTitleMatch.Groups["torment"].Success,
              Text = text
            };
            abilities.Add(ability);
          }
        }

        _context.ModelCards.Add(entity);

        // Save to generate ID
        await _context.SaveChangesAsync();

        foreach (var attack in attacks)
        {
          attack.CardId = entity.Id;
        }

        foreach (var ability in abilities)
        {
          ability.CardId = entity.Id;
        }

        await _context.Attacks.AddRangeAsync(attacks);
        await _context.Abilities.AddRangeAsync(abilities);

        await _context.SaveChangesAsync();
      }

      return RedirectToPage("/Factions/Edit", new { id = ViewModel.FactionId });
    }
  }
}