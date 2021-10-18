using Backend_Preguntas_Repuestas.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Preguntas_Repuestas.Domain.IServices
{
    public interface IUsuarioService
    {
        Task SaveUser(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);
        Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior);
        Task UpdatePassword(Usuario usuario);
    }
}
