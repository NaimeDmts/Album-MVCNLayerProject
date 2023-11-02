using AutoMapper;
using MVCNLayerProject.BLL.DTOs.AlbumDTOs;
using MVCNLayerProject.BLL.DTOs.AppUserDTOs;
using MVCNLayerProject.BLL.DTOs.SanatciDTOs;
using MVCNLayerProject.BLL.DTOs.TurDTOs;
using MVCNLayerProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.BLL.AutoMapper
{
    public class Mapping :Profile
    {
        public Mapping()
        {
            CreateMap<Album,AlbumCreateDTO>().ReverseMap();
            CreateMap<Album,AlbumDTO>().ReverseMap();
            CreateMap<Album,AlbumUpdateDTO>().ReverseMap();

            CreateMap<Tur,TurDTO>().ForMember(desc=>desc.Albums, opt=>opt.MapFrom(t=>t.Albums)).ReverseMap();
            CreateMap<Tur, TurCreateDTO>().ReverseMap();
            CreateMap<Tur,TurUpdateDTO>().ReverseMap();

            CreateMap<Sanatci, SanatciDTO>().ForMember(desc => desc.Albums, opt => opt.MapFrom(t => t.Albums)).ReverseMap();
            CreateMap<Sanatci, SanatciCreateDTO>().ReverseMap();
            CreateMap<Sanatci, SanatciUpdateDTO>().ReverseMap();

            CreateMap<AppUser,RegisterDTO>().ReverseMap();
            CreateMap<AppUser, LoginDTO>().ReverseMap();


        }
    }
}
