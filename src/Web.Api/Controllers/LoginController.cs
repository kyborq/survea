using Core.Entities;
using DatabaseStorage.Abstractions.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Utils.Extensions;
using Web.Api.Dtos;

namespace Web.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public LoginController( IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login( [FromBody] LoginDto dto )
        {
            User user = _userRepository.GetByEmail( dto.Email );
            if ( user == null )
            {
                return Forbid();
            }
            if ( !user.PasswordHash.Equals( dto.Password.GetHash() ) )
            {
                return Forbid();
            }
            var claims = new List<Claim> 
                { new Claim( ClaimTypes.Name, user.UserId.ToString() ), new Claim( ClaimTypes.Email, user.Email ) };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity( claims, "Cookies" );
            await HttpContext.SignInAsync( 
                CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal( claimsIdentity ) );
            return Ok( user.UserId );
        }

        [HttpPost]
        [Route( "logout" )]
        public void Logout()
        {
            HttpContext.SignOutAsync();
        }
    }
}
