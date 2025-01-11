using Libreria.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Acceso.Datos.Repositorio.EF
{
    public class LibreriaContext : DbContext
    {
        //Constructor
        public LibreriaContext(DbContextOptions<LibreriaContext> opciones) : base(opciones)
        {

        }
       
        
        //DbSets
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Atleta> Atletas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<PuntajeAtleta> PuntajesAtletas { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }

    }
}
