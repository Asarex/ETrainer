using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETrainerWebAPI.Models;
using ETrainerWebAPI.Models.DTO;

namespace ETrainerWebAPI.Profiles
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<ETrainerUser, UserRegisterInfo>()
				.ForMember(dest => dest.DisplayName,
					opt => opt.MapFrom(src => src.DisplayedName))
				.ForMember(dest => dest.Login,
					opt => opt.MapFrom(src => src.UserName))
				.ForMember(dest => dest.Email,
					opt => opt.MapFrom(src => src.Email))
				.ReverseMap();
		}
	}
}
