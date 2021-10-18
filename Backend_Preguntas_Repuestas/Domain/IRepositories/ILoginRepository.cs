using Backend_Preguntas_Repuestas.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Preguntas_Repuestas.Domain.IRepositories
{
    public interface ILoginRepository
    {
        Task<Usuario> ValidateUser(Usuario usuario);
    }
}
