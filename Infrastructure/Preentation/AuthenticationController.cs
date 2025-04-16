namespace Presentation
{
    public class AuthenticationController(IServiceManager serviceManager) : ApiController
    {
        [HttpPost("Login")]
        public async Task<ActionResult<UserResultDto>> Login( LoginDto loginDto)
        {
            var user = await serviceManager.AuthenticationService.LoginAsync(loginDto);
            return Ok(user);
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserResultDto>> Register(RegisterDto registerDto)
        {
            var user = await serviceManager.AuthenticationService.RegisterAsync(registerDto);
            return Ok(user);
        }
    }
}
