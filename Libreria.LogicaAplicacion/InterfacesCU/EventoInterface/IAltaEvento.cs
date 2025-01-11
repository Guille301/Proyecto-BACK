using Compartido.DTOS.Atleta;
using Compartido.DTOS.Disciplina;
using Compartido.DTOS.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCU.EventoInterface
{
    public interface IAltaEvento
    {

        void Ejecutar(EventoAltaDto eventoAltaDto);

        EventoAltaDto HacerAltaEvento();
    }
}
