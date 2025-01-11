using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEvento : IRepositorio<Evento>
    {
        public IEnumerable<PuntajeAtleta> FindAtletasDelEvento(int idEvento);
        public IEnumerable<Evento> FindAllByAtletaId(int id);

        //IEnumerable<LogicaNegocio.Entidades.Evento> EjecutarListarEventosPorAtleta(int id);

        public PuntajeAtleta RegistroPuntaje(PuntajeAtleta PuntajeNuevo);
        public bool FindByNombre(string nombreEvento);
        public List<Evento> FindAllByDate(DateTime fecha);



        public List<Evento> FiltroEvento(int? disciplinaId, DateTime? fechaInicio, DateTime? fechaFin, string? nombreEvento, int? puntajeMin, int? puntajeMax);

        public bool DisciplinaEstaEnEventos(int idDisciplina);


    }
}
