using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SelfieAPokemon.Core.Application.Models.DTOs;
using SelfieAPokemon.Core.Application.Models.ViewModel.User;
using SelfieAPokemon.Core.Application.Services.Interfaces;
using SelfieAPokemon.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfieAPokemon.API.UI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        #region properties
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenService _jwtTokenService;
        #endregion
        #region constructeur

        public AccountController(UserManager<User> userManager, IJwtTokenService jwtTokenService)
        {
            this._userManager = userManager;
            this._jwtTokenService = jwtTokenService;
        }
        #endregion

        #region public methods

        [HttpPost]
        [Route("sign-in")]
        public async Task<ActionResult<UserDto>> SignIn([FromBody] UserLoginViewModel model)
        {
            var user = await this._userManager.FindByEmailAsync(model.Email);
            if(user != null)
            {
                var userAuth = await this._userManager.CheckPasswordAsync(user, model.Password);
                if (userAuth)
                {
                    return Ok(new UserDto()
                    {
                        Email = user.Email,
                        Name = user.UserName,
                        Token = this._jwtTokenService.GenerateJwtToken(user)
                    });
                }
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("Sign-up")]
        public async Task<ActionResult<UserDto>> SignUp([FromBody] UserRegisterViewModel model)
        {
            string name = !string.IsNullOrEmpty(model.Name) ? model.Name : model.Email;
            var userCreated = await this._userManager.CreateAsync(new Core.Domain.User() { 
                    Email = model.Email, UserName =name
                }, model.Password );
            if (!userCreated.Succeeded)
            {
                return BadRequest(new { errors = userCreated.Errors.Select(e => e.Description) });
            }


            return Ok(new UserDto() { Name = name, Email = model.Email, Token = null});
        }
        #endregion
    }
}
