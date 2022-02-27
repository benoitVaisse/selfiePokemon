using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SelfieAPokemon.Core.Application.Models.DTOs;
using SelfieAPokemon.Core.Application.Models.ViewModel.User;
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
        #endregion
        #region constructeur

        public AccountController(UserManager<User> userManager)
        {
            this._userManager = userManager;
        }
        #endregion

        #region public methods

        [HttpPost]
        [Route("Sign-up")]
        public async Task<ActionResult<UserDto>> SignUp([FromBody] UserRegisterViewModel model)
        {
            string name = !string.IsNullOrEmpty(model.Name) ? model.Name : model.Email;
            var tt = await this._userManager.CreateAsync(new Core.Domain.User() { 
                    Email = model.Email, UserName =name
                }, model.Password );
            if (!tt.Succeeded)
            {
                return BadRequest(new { errors = tt.Errors.Select(e => e.Description) });
            }


            return Ok(new UserDto() { Name = name, Email = model.Email, Token = null});
        }
        #endregion
    }
}
