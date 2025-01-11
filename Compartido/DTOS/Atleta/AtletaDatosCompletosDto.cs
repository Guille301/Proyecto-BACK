using Compartido.DTOS.Disciplina;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Atleta
{
    public class AtletaDatosCompletosDto
    {
        public AtletaDatosCompletosDto()
        {
        }

        public AtletaDatosCompletosDto(int atletaId)
        {
          //  AtletaId = atletaId;
        }

        public string PaisNombre { get; set; }
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Sexo { get; set; }


        public int Id { get; set; }


        public List<DisciplinaDatosCompletos> Disciplinas { get; set; } = new List<DisciplinaDatosCompletos>();
        



        //   public record AtletaDatosCompletosDto(int Id, string Nombre, string CorreoElectronico, DateTime FechaNacimiento, DateTime? FechaDefuncion = null);





    }
}
