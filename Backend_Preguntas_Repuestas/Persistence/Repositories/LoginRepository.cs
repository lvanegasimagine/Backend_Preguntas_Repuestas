using Backend_Preguntas_Repuestas.Domain.IRepositories;
using Backend_Preguntas_Repuestas.Domain.models;
using Backend_Preguntas_Repuestas.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Preguntas_Repuestas.Persistence.Repositories
{
    public class LoginRepository: ILoginRepository
    {
        private readonly AplicationDbContext _context;
        public LoginRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            var user = await _context.Usuario.Where(x => x.NombreUsuario == usuario.NombreUsuario && x.Password == usuario.Password).FirstOrDefaultAsync();
            return user;
        }
    }
}
