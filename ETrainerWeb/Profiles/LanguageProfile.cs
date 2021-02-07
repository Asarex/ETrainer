using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETrainerWebAPI.Models;
using ETrainerWebAPI.Models.DTO;

namespace ETrainerWebAPI.Profiles
{
	public class LanguageProfile : Profile
	{
		public LanguageProfile()
		{
			CreateMap<Language, LanguageInfo>()
				.ForMember(dest => dest.Language,
					opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.LanguageId,
					opt => opt.MapFrom(src => src.ID))
				.ReverseMap();
		}
	}
}
