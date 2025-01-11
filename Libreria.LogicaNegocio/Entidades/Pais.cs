using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CantHabitantes { get; set; }
        public string TelefonoContacto { get; set; }

        public Pais()
        {

        }

        public Pais(string nombre, int cantHabitantes, string telefonoContacto)
        {
            Nombre = nombre;
            CantHabitantes = cantHabitantes;
            TelefonoContacto = telefonoContacto;
        }
    }
}
