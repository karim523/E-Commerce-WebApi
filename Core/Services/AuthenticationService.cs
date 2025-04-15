
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Services
{
    class AuthenticationService(UserManager<User> _userManager) : IAuthenticationService
    {
        public async Task<UserResultDto> LoginAsync(LoginDto loginDto)
        {
            //Email is already addded to the database
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user is null) throw new UnauthorizedException(); //User not found 

            //Password is correct
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result) throw new UnauthorizedException(); //Password is incorrect

            return new UserResultDto(user.DisplayName,"Token",user.Email);
        }

        public Task<UserResultDto> RegisterAsync(RegisterDto registerDto)
        {
            throw new NotImplementedException();
        }
    }
}
