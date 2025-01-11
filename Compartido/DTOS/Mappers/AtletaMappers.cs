using Compartido.DTOS.Atleta;
using Compartido.DTOS.Disciplina;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Mappers
{
    public class AtletaMappers
    {
        public static AtletaDatosCompletosDto ToAtletaBasicoDto(Libreria.LogicaNegocio.Entidades.Atleta atletas)
        {
            
            AtletaDatosCompletosDto dto = new AtletaDatosCompletosDto();
            dto.Nombre = atletas.Nombre;
            dto.Apellido = atletas.Apellido;
            dto.PaisNombre = atletas.Pais.Nombre;
            dto.Sexo = atletas.Sexo;
            dto.Id = atletas.Id;
            

            


            foreach (Libreria.LogicaNegocio.Entidades.Disciplina disciplina in atletas.Disciplinas) 
            {
                
                Libreria.LogicaNegocio.Entidades.Disciplina Dis = new Libreria.LogicaNegocio.Entidades.Disciplina();
                Dis = disciplina;
                DisciplinaDatosCompletos  dtoDisc = Mappers.DisciplinaMappers.ToDisciplinaBasicoDto(Dis);

                dto.Disciplinas.Add(dtoDisc);
            }
            
            return dto;

        }

        public void AsignarDisciplina(Libreria.LogicaNegocio.Entidades.Atleta atletaDto , Libreria.LogicaNegocio.Entidades.Disciplina disciplinaDto)
        {
            
            Libreria.LogicaNegocio.Entidades.Disciplina disciplina = new Libreria.LogicaNegocio.Entidades.Disciplina
            {
                Id = disciplinaDto.Id,
                Nombre = disciplinaDto.Nombre
                
            };

            
            atletaDto.AsignarDisciplina(disciplina);
        }


        public static List<ListarAtletaDto> FromListAtletaToListDtoListarAtletas(List<Libreria.LogicaNegocio.Entidades.Atleta> atl)
        {
            List<ListarAtletaDto> ret = new List<ListarAtletaDto>();

            foreach (Libreria.LogicaNegocio.Entidades.Atleta atleta in atl)
            {
                ListarAtletaDto dtoListarAtletas = new ListarAtletaDto();
                dtoListarAtletas.id = atleta.Id;
                dtoListarAtletas.Nombre = atleta.Nombre;
                dtoListarAtletas.Apellido = atleta.Apellido;
                dtoListarAtletas.PaisNombre = atleta.Pais.Nombre;
                ret.Add(dtoListarAtletas);
            }
            return ret;
        }












    }
}
