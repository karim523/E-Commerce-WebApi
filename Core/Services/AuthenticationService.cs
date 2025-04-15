using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

            return new UserResultDto(user.DisplayName, await CreateTokenAsync(user), user.Email);
        }

        public async Task<UserResultDto> RegisterAsync(RegisterDto registerDto)
        {
            var user = new User()
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                DisplayName = registerDto.DisplayName,
                PhoneNumber = registerDto.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                throw new ValidationException(errors);
            }

            return  new UserResultDto(user.DisplayName, await CreateTokenAsync(user), user.Email);
        }
        private async Task<string> CreateTokenAsync(User user)
        {
            //private claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.DisplayName),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("12b9e7e4673d6979e7116c2150317a2dc358c863cd5420b8dee94853f69442df2a59f1b8fd99919c6e5d6d3eb1eb173f20324f8cf6ca22ad6be7f476deba1b50bfc4ff09910bf3035893918c1a3f529f55a6a0ebd14ac89b51827a02119df2130ffe0877501f4b7347bcf93acbf3e10b16e6c88faf496476ef9c871c7f8da5d95bb391d98d786c2d58d46193f47b16caee6783093df3e912325c717800d6effc69d12bec8780f6cdbc56d23f901696756b301bbbdd6d96076ceaea9ff9e03163e1fc965393b29de7773a10ae768858e3aaac7371d0007d7618d233a91b5a6288697a5bc66dd9fe5a18e7a70419d1d91a98b281b11fb85e8def657b9566ddc2b7"));
            var siginCreds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "http://localhost:5124",
                audience: "My audience",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: siginCreds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
