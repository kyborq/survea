using DatabaseStorage.Abstractions.Repositories;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Dtos;
using Web.Api.Mappings;

namespace Web.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController( IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        [HttpGet( "{id}" )]
        public UserDto GetUser( [FromRoute] int id )
        {
            return _userRepository.GetById( id )?.MapToDto();
        }

        [HttpGet( "{id}/full" )]
        public UserFullInfoDto GetUserFullInfo( [FromRoute] int id )
        {
            return _userRepository.GetWithFullInfoById( id )?.MapToFullInfoDto();
        }

        [HttpPost]
        public void AddUser( [FromBody] UserFullInfoDto dto )
        {
            //_userService
        }
    }
}
