using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETrainerWebAPI.Models;
using ETrainerWebAPI.Models.DTO;

namespace ETrainerWebAPI.Profiles
{
	public class MuscleProfile : Profile
	{
		public MuscleProfile()
		{
			CreateMap<MuscleTranslatedInfo, LocalizedMuscle>()
				.ForMember(dest => dest.Description,
					opt => opt.MapFrom(src => src.Description))
				.ForMember(dest => dest.Name,
					opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.LanguageId,
					opt => opt.MapFrom(src => src.Language.ID))
				.ReverseMap();
		}
	}
}
