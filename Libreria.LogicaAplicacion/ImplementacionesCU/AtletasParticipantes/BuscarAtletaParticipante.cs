using Compartido.DTOS.Disciplina;
using Compartido.DTOS.Mappers;
using Compartido.DTOS.PuntajeAtleta;
using Libreria.LogicaAplicacion.InterfacesCU.AtletasParticipantesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.AtletasParticipantes
{
    public class BuscarAtletaParticipante : IBuscarAtletaEnEvento
    {
        private LogicaNegocio.InterfacesRepositorios.IRepositorioAtletasParticipantes _repoAtletasParticipantes;

        public BuscarAtletaParticipante(LogicaNegocio.InterfacesRepositorios.IRepositorioAtletasParticipantes repoAtlePart)
        {
            _repoAtletasParticipantes = repoAtlePart;
        }

        public ListarAtletasDeLosEventosDto Ejecutar(int idAtleta, int idEvento)
        {
            // Buscar el puntaje del atleta utilizando los identificadores de atleta y evento
            LogicaNegocio.Entidades.PuntajeAtleta PA = _repoAtletasParticipantes.FindByIdEspecifico(idAtleta, idEvento);

            // Convertir la entidad a DTO para pasarlo a la vista
            ListarAtletasDeLosEventosDto PADto = AtletasParticipantesMapper.ToParticipantesBasictoDto(PA);

            return PADto;
        }
    }


















}

