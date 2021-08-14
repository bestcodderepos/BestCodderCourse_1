using BestCodder.Api.Helper;
using BestCodder.Common;
using BestCodder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestCodder.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ITokenService tokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] UserRequestDto userRequestDto)
        {
            if (userRequestDto is null || !ModelState.IsValid)
                return BadRequest();

            var user = new IdentityUser
            {
                UserName = userRequestDto.Email,
                Email = userRequestDto.Email,
                PhoneNumber = userRequestDto.PhoneNo,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRequestDto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new Result<IEnumerable<string>>(false, ResultConstant.IdNotNull, errors));
            }

            //var roleResult = await _userManager.AddToRoleAsync(user, ResultConstant.Role_Customer);
            //if (!roleResult.Succeeded)
            //{
            //    var errors = roleResult.Errors.Select(e => e.Description);
            //    return BadRequest(new Result<IEnumerable<string>>(false, ResultConstant.IdNotNull, errors));
            //}
            return StatusCode(201);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SignInDto signInDto)
        {
            var result = await _signInManager.PasswordSignInAsync(signInDto.UserName, signInDto.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(signInDto.UserName);
                if (user is null)
                    return Unauthorized(new Result<IActionResult>(false, ResultConstant.InvalidAuthentication));

                var returnData = new UserDto
                {
                    UserName = user.UserName,
                    Id = user.Id,
                    Email = user.Email,
                    PhoneNo = user.PhoneNumber,
                    Token = _tokenService.CreateToken(user)
                };
                return Ok(new Result<UserDto>(true, ResultConstant.TokenResponseMessage, returnData));
            }
            else
                return Unauthorized(new Result<IActionResult>(false, ResultConstant.InvalidAuthentication));
        }

    }
}
