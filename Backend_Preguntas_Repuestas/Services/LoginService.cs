using Backend_Preguntas_Repuestas.Domain.IRepositories;
using Backend_Preguntas_Repuestas.Domain.IServices;
using Backend_Preguntas_Repuestas.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Preguntas_Repuestas.Services
{
    public class LoginService: ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            return await _loginRepository.ValidateUser(usuario);
        }
    }
}
