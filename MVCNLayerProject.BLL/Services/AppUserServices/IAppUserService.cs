using Microsoft.AspNetCore.Identity;
using MVCNLayerProject.BLL.DTOs.AppUserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.BLL.Services.AppUserServices
{
    public interface IAppUserService
    {
        Task<IdentityResult> Register(RegisterDTO registerDTO);
        Task<IdentityResult> DeleteUser(string Id);
        Task<bool> Login(LoginDTO loginDTO);
        Task LogOut();

    }
}
