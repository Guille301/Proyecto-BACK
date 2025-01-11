using Libreria.LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class Disciplina
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public DateTime AnoDeIntegracion { get; set; }

        public List<Atleta> Atletas { get; set; }


        public Disciplina() { }

        public Disciplina(string nombre, DateTime anoDeIntegracion, List<Atleta> atletas)
        {
            Nombre = nombre;
            AnoDeIntegracion = anoDeIntegracion;
            Atletas = atletas;
        }

        public Disciplina(string nombre, DateTime anoDeIntegracion)
        {
            Nombre = nombre;
            AnoDeIntegracion = anoDeIntegracion;
        }

        public Disciplina(int id, string nombre, DateTime anoDeIntegracion)
        {
            Id = id;
            Nombre = nombre;
            AnoDeIntegracion = anoDeIntegracion;
        }

        public bool esValido()
        {
            // Validar longitud del nombre Y año de integración
            if (this.Nombre.Length >= 10 && this.Nombre.Length <= 50 && AnoDeIntegracion.Year < DateTime.Now.Year)
            {
                return true;
            }

            return false;
        }





    }
}
