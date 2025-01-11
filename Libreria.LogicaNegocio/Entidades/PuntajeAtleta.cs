using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades{
[PrimaryKey(nameof(EventoId), nameof(AtletaId))]

    public class PuntajeAtleta
    {
  

        public int PuntosAtletas { get; set; }
        [ForeignKey(nameof(Evento))]
        public int EventoId { get; set; }
        [ForeignKey(nameof(Atleta))]
        public int AtletaId { get; set; }
        public  Evento  Evento { get; set; }
        public Atleta  Atleta{ get; set; }


      public  PuntajeAtleta()
      {

      }

        public PuntajeAtleta(int puntosAtletas)
        {
            PuntosAtletas = puntosAtletas;
        }
    }
}
