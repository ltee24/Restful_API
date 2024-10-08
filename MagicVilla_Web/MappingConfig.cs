﻿using AutoMapper;
using MagicVilla_Web.Models.DTO;
namespace MagicVilla_Web
{
	public class MappingConfig :Profile
	{
        public MappingConfig()
        {
           
            CreateMap<VillaDTO, VillaCreateDTO>();
            CreateMap<VillaDTO, VillaUpdateDTO>();

            

            CreateMap<VillaNumberDTO, VillaCreateNumberDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, VillaUpdateNumberDTO>().ReverseMap();

        }
    }
}
