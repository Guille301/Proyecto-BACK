using Compartido.DTOS.Atleta;
using Compartido.DTOS.PuntajeAtleta;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Evento
{
    public class EventoDto 
    {

   
        public int Id { get; set; }

        public Libreria.LogicaNegocio.Entidades.Disciplina disciplina { get; set; }
        public string NombreDePrueba { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaDeFin { get; set; }
       // public List<Libreria.LogicaNegocio.Entidades.PuntajeAtleta> AtletasParticipantes { get; set; }

        public List<AtletaDatosCompletosDto> atleta { get; set; }








    }

    //UN dto no puede concer objetos, debe conocer dtos.               
    ///Se debe cambiar esto a un dtos de puntaje atleta que debo crear


   


}
