using Backend_Preguntas_Repuestas.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Preguntas_Repuestas.Domain.IServices
{
    public interface ILoginService
    {
        Task<Usuario> ValidateUser(Usuario usuario);
    }
}
