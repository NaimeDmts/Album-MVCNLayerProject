using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MVCNLayerProject.BLL.DTOs.AppUserDTOs;
using MVCNLayerProject.CORE.Entities;
using MVCNLayerProject.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNLayerProject.BLL.Services.AppUserServices
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> DeleteUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            user.DeleteDate = DateTime.Now;
            user.Status = Status.Passive;
            IdentityResult result = await _userManager.UpdateAsync(user);
            return result;

        }

        public async Task<bool> Login(LoginDTO loginDTO)
        {
          AppUser user = await _userManager.FindByNameAsync(loginDTO.UserName);
            if (user != null)
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, true, false);
                if (result.Succeeded)
                {
                    return true;
                }

                else
                {
                    throw new Exception("Hatalı Giriş");
                }
            }
            else
            {
                throw new Exception("Kullanıcı Bulunamadı");
            }
        }

        public async Task LogOut()
        {
           await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterDTO registerDTO)
        {
            var appUser = _mapper.Map<AppUser>(registerDTO);
            var result = await _userManager.CreateAsync(appUser, registerDTO.Password);
            return result;
        }
    }
}
