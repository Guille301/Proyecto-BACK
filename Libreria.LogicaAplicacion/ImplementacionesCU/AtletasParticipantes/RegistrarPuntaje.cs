using Compartido.DTOS.Mappers;
using Compartido.DTOS.PuntajeAtleta;
using Compartido.DTOS.Usuario;
using Libreria.LogicaAplicacion.InterfacesCU.AtletasParticipantesInterface;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Eventos;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.AtletasParticipantes
{
    public class RegistrarPuntaje : IRegistrarPuntaje
    {

        private IRepositorioAtletasParticipantes _repoPar;


        public RegistrarPuntaje(IRepositorioAtletasParticipantes repo)
        {

            _repoPar = repo;


        }



        public void Ejecutar(ListarAtletasDeLosEventosDto PuntajeDto)
        {
            if (PuntajeDto.PuntosAtletas < 0)
            {
                throw new PuntosInvalidos("Error de puntaje");
            }
            var Puntaje = _repoPar.FindByIdEspecifico(PuntajeDto.idAtleta, PuntajeDto.idEvento);

            Puntaje.PuntosAtletas = PuntajeDto.PuntosAtletas;



            _repoPar.Update(Puntaje);
        }





    }
}
