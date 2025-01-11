using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Libreria.LogicaNegocio.Entidades
{
    [Index(nameof(NombreDePrueba), IsUnique = true)]
    public class Evento
    {
        public int Id { get; set; }

        public Disciplina Disciplina { get; set; }
        public string NombreDePrueba { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaDeFin { get; set; }
   public List<PuntajeAtleta> AtletasParticipantes { get; set; }

    
        public Evento(Disciplina disciplina, string nombreDePrueba, DateTime fechaDeInicio, DateTime fechaDeFin, List<PuntajeAtleta> atletasP)
        {
            Disciplina = disciplina;
            NombreDePrueba = nombreDePrueba;
            FechaDeInicio = fechaDeInicio;
            FechaDeFin = fechaDeFin;
            AtletasParticipantes = atletasP;
        }


        public Evento(Disciplina disciplina, int id)
        {

        }

        public Evento() { }


    }
}
