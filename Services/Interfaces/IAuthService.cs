using ClaseEntityFramework.DTOs.Auth;

namespace ClaseEntityFramework.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
        bool ValidatePasswordAsync(string password, string hashedPassword);
        string HashPassword(string password);
    }
}
