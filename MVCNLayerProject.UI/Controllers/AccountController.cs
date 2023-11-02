using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCNLayerProject.BLL.DTOs.AppUserDTOs;
using MVCNLayerProject.BLL.Services.AppUserServices;
using MVCNLayerProject.UI.Models.ViewModels.AppUserVM;

namespace MVCNLayerProject.UI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAppUserService _service;
        private readonly IMapper _mapper;

        public AccountController(IAppUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                RegisterDTO registerDTO = _mapper.Map<RegisterDTO>(registerVM);
                IdentityResult result = await _service.Register(registerDTO);
                if(result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description.ToString());
                    }
                }
            }
            return View();

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var loginDTO = _mapper.Map<LoginDTO>(loginVM);
                bool login = await _service.Login(loginDTO);
                if (login)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Content("Giriş Gerçeklerşmedi");
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _service.LogOut();
            return RedirectToAction("Index", "Home");

        }
    }
}
