using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class AuthenticateController : ControllerBase
{
    private readonly IAuthService _authService;
        private readonly IConfiguration _config;

        /// <summary>
        /// Constructor para el controlador.
        /// </summary>
        /// <param name="config">Configuración de la aplicacion</param>
        /// <param name="authService">Servicio de autenticacion</param>
        public AuthenticateController(IConfiguration config, IAuthService authService)
        {
            _config = config;
            _authService = authService;
        }

        /// <summary>
        /// Autentica a un usuario y devuelve un token JWT.
        /// </summary>
        /// <param name="credentials">dto con las credenciales del usuario.</param>
        /// <returns>token si las credenciales son validas.</returns>
        /// <remarks>
        /// Devuelve un token JWT
        /// </remarks>
        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(CredentialsForAuthenticateDto credentials)
        {
            string token = _authService.Authenticate(credentials);
            return Ok(token);
        }
}