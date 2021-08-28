using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using NicosApp.Core.Entidades;
using NicosApp.Core.Excepciones;
using NicosApp.Core.Interfaces.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace NicosApp.Core.Features.Seguridad.Commands.Login
{
    public class LoginCommandHandle : IRequestHandler<LoginUsuarioCommand, TokenDto>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        /// <summary>
        /// 
        /// </summary>
        private readonly SignInManager<ApplicationUser> _signInManager;
        /// <summary>
        /// 
        /// </summary>
        private readonly IJwtGenerador _jwtGenerador;
        /// <summary>
        /// 
        /// </summary>
        private readonly ICurrentUserService _currentUserService;
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger _logger;



        private static string RENOVACION_PLAN = "RENOVACION_PLAN";


        public LoginCommandHandle(UserManager<ApplicationUser> userManager,
                            SignInManager<ApplicationUser> signInManager,
                            IJwtGenerador jwtGenerador,
                            ICurrentUserService currentUserService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerador = jwtGenerador;
            _currentUserService = currentUserService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TokenDto> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
        {

            var userId = _currentUserService.UserId ?? string.Empty;
            string userName = "";

            var usuario = await _userManager.FindByEmailAsync(request.Email);




            if(!usuario.Estatus)
            {
                throw new UnauthorizedExeption(RENOVACION_PLAN);
            }
         


            if (usuario == null)
            {
                string mensaje = "Email o password invalidos";             

                throw new UnauthorizedExeption( mensaje);
            }
            //if (!await _userManager.IsEmailConfirmedAsync(usuario))
            //{
            //    string mensaje = "Debe tener un correo electrónico confirmado para iniciar sesión.";

            //    throw new UnauthorizedExeption(mensaje);
            //}
            var resultado = await _signInManager.CheckPasswordSignInAsync(usuario, request.Password, false);

            if (!string.IsNullOrEmpty(userId))
            {
                ApplicationUser applicationUser = new ApplicationUser
                {
                    Email = request.Email,
                    UserName = request.Email
                };
                userName = await _userManager.GetUserNameAsync(applicationUser);
            }

            if (resultado.Succeeded)
            {
                return new TokenDto
                {
                    Token = _jwtGenerador.crearToken(usuario),
                    Nombre = usuario.Nombre,
                    Email = usuario.Email
                };
            }
            throw new UnauthorizedExeption( "email o contraseña inválida");
        }
    }
}
