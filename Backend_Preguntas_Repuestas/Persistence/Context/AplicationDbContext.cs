using Backend_Preguntas_Repuestas.Domain.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Preguntas_Repuestas.Persistence.Context
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
