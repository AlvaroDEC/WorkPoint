namespace ClaseEntityFramework.DTOs.Auth
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string TokenType { get; set; } = "Bearer";
        public string RefreshToken { get; set; }
    }
}
