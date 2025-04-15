namespace Services.Abstraction
{
    public interface IAuthenticationService
    {
        Task<UserResultDto> RegisterAsync(RegisterDto registerDto);
        Task<UserResultDto> LoginAsync(LoginDto loginDto);
    }
}
