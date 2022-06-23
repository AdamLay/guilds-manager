﻿using AutoMapper;
using GuildsManager.Web.Data;
using GuildsManager.Web.ViewModels.ModelCards;

namespace GuildsManager.Web;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<ModelCard, ModelCardViewModel>().ReverseMap();
  }
}