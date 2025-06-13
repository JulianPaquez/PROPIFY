namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authenticate(CredentialsForAuthenticateDto request);
    }
}