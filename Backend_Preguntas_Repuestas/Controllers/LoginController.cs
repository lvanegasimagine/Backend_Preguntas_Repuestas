using Backend_Preguntas_Repuestas.Domain.IServices;
using Backend_Preguntas_Repuestas.Domain.models;
using Backend_Preguntas_Repuestas.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Preguntas_Repuestas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Usuario usuario)
        {
            try
            {
                usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
                var user = await _loginService.ValidateUser(usuario);

                if(user == null)
                {
                    return BadRequest(new { message = "Usuario o Contraseña invalidos"});
                }

                return Ok(new { usuario = user.NombreUsuario });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
