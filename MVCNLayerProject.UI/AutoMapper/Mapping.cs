using AutoMapper;
using MVCNLayerProject.BLL.DTOs.AppUserDTOs;
using MVCNLayerProject.CORE.Entities;
using MVCNLayerProject.UI.Models.ViewModels.AppUserVM;

namespace MVCNLayerProject.UI.AutoMapper
{
    public class Mapping :Profile
    {
        public Mapping()
        {
            CreateMap<RegisterDTO, RegisterVM>().ReverseMap();
            CreateMap<LoginDTO, LoginVM>().ReverseMap();
        }
    }
}
