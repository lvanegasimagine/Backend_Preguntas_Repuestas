﻿using Backend_Preguntas_Repuestas.Domain.IRepositories;
using Backend_Preguntas_Repuestas.Domain.models;
using Backend_Preguntas_Repuestas.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Preguntas_Repuestas.Persistence.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly AplicationDbContext _context;
        public UsuarioRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveUser(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Usuario usuario)
        {
            var validateExistence = await _context.Usuario.AnyAsync(x => x.NombreUsuario == usuario.NombreUsuario);
            return validateExistence;
        }

        public async Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior)
        {
            var usuario = await _context.Usuario.Where(x => x.Id == idUsuario && x.Password == passwordAnterior).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task UpdatePassword(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
