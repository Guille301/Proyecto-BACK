using Compartido.DTOS.Atleta;
using Compartido.DTOS.Disciplina;
using Libreria.LogicaAplicacion.InterfacesCU.DisciplinaInterface;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Disciplinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.Disciplina
{
    public class ObtenerDisciplina : IObtenerDisciplina
    {
        private LogicaNegocio.InterfacesRepositorios.IRepositorioDisciplina _repoDisciplina; 


        public ObtenerDisciplina(LogicaNegocio.InterfacesRepositorios.IRepositorioDisciplina repoDisciplina)
        {
            this._repoDisciplina = repoDisciplina;
        }

        public IEnumerable<DisciplinaDatosCompletos> Ejecutar()
        {
            var disciplinas = _repoDisciplina.FindAllOrdenado();
 
 
     if (!disciplinas.Any()) {
        throw new NoHayDisciplinas("No hay disciplinas");
    }

            var disciplinasDto = disciplinas.Select(d => Compartido.DTOS.Mappers.DisciplinaMappers.ToDisciplinaBasicoDto(d));
            return disciplinasDto;
        }








    }
}
