using AutoMapper;
using GuildsManager.Web.Data;
using GuildsManager.Web.Responses;
using GuildsManager.Web.ViewModels.Abilities;
using GuildsManager.Web.ViewModels.Attacks;
using GuildsManager.Web.ViewModels.ModelCards;

namespace GuildsManager.Web;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<ModelCard, ModelCardViewModel>().ReverseMap();
    CreateMap<Ability, AbilityViewModel>().ReverseMap();
    CreateMap<Attack, AttackViewModel>().ReverseMap();
    
    CreateMap<ModelCard, ModelCardResponse>();
    CreateMap<Ability, AbilityResponse>();
    CreateMap<Attack, AttackResponse>();
  }
}