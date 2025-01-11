using Compartido.DTOS.Disciplina;
using Compartido.DTOS.Mappers;
using Libreria.LogicaAplicacion.InterfacesCU.DisciplinaInterface;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Disciplinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.Disciplina
{
    public class BuscarDisciplina: IBuscarDisciplina
    {

        private LogicaNegocio.InterfacesRepositorios.IRepositorioDisciplina _repoDisciplina; 

        public BuscarDisciplina(LogicaNegocio.InterfacesRepositorios.IRepositorioDisciplina repositorioDisciplina)
        {
            _repoDisciplina = repositorioDisciplina;
        }


        DisciplinaDatosCompletos IBuscarDisciplina.Ejecutar(int id)
        {
            LogicaNegocio.Entidades.Disciplina dis = _repoDisciplina.FindById(id);

            DisciplinaDatosCompletos disciplinaDto = DisciplinaMappers.ToDisciplinaBasicoDto(dis);

            return disciplinaDto;
        }

        public DisciplinaDatosCompletos EjecutarPorNombre(string nombre)
        {
            var disciplina = _repoDisciplina.FindByName(nombre);

            var disciplinaDto = Compartido.DTOS.Mappers.DisciplinaMappers.MapearDisciplinaASeguro(disciplina);

            return disciplinaDto;
        }

    }
}
