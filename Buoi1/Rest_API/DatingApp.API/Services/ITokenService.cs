namespace DatingApp.API.Services
{
    public interface ITokenService
    {
        string CreateToken(string username);
    }
}
