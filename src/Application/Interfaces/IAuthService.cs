namespace Application.Interfaces
{
    public interface IAuthService
    {
        string Authenticate(CredentialsForAuthenticateDto credentials);

    }
}