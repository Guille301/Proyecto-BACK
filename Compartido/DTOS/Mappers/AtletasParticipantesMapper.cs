using Compartido.DTOS.Disciplina;
using Compartido.DTOS.PuntajeAtleta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Mappers
{
    public class AtletasParticipantesMapper
    {


        public static ListarAtletasDeLosEventosDto ToParticipantesBasictoDto(Libreria.LogicaNegocio.Entidades.PuntajeAtleta Pa)
        {
            return new ListarAtletasDeLosEventosDto
            {
                idEvento = Pa.EventoId,
                idAtleta = Pa.AtletaId,
                Nombre = Pa.Atleta.Nombre,
                PuntosAtletas = Pa.PuntosAtletas,

            };
        }


    }
}
