using Compartido.DTOS.Atleta;
using Compartido.DTOS.Disciplina;
using Compartido.DTOS.Usuario;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Mappers
{
    public class DisciplinaMappers
    {

        /**** Alta ****/
        public static Libreria.LogicaNegocio.Entidades.Disciplina FromUsuarioDisciplinaDto(DisciplinaAltaDto DA)
        {
            return new Libreria.LogicaNegocio.Entidades.Disciplina(DA.Nombre,DA.AnoDeIntegracion);

        }


        public static DisciplinaDatosCompletos ToDisciplinaBasicoDto(Libreria.LogicaNegocio.Entidades.Disciplina disciplina)
        {
            return new DisciplinaDatosCompletos
            {
                Nombre = disciplina.Nombre,
                Id = disciplina.Id,
                AnoDeIntegracion = disciplina.AnoDeIntegracion,
            };
        }

        public static DisciplinaDatosCompletos MapearDisciplinaASeguro(Libreria.LogicaNegocio.Entidades.Disciplina disciplina)
        {
            if (disciplina == null)
            {
                throw new ArgumentNullException(nameof(disciplina), "El objeto Disciplina no puede ser nulo al intentar mapearlo.");
            }
            return new DisciplinaDatosCompletos
            {
                Nombre = disciplina.Nombre,
                Id = disciplina.Id,
                AnoDeIntegracion = disciplina.AnoDeIntegracion,
            };
        }


        public static Libreria.LogicaNegocio.Entidades.Disciplina FromDisciplinaDatosCompletos(DisciplinaDatosCompletos DA)
        {
            return new Libreria.LogicaNegocio.Entidades.Disciplina
            {
                Nombre = DA.Nombre,
                Id = DA.Id,
                AnoDeIntegracion = DA.AnoDeIntegracion,
            };

        }

        public static Libreria.LogicaNegocio.Entidades.Disciplina FromDto(DisciplinaDatosCompletos dto)
        {
            //IMPLEMENTAR
            return new Libreria.LogicaNegocio.Entidades.Disciplina();
        }



        public static List<ListarDisciplina> FromListDisciplinaToListDtoDisciplina(List<Libreria.LogicaNegocio.Entidades.Disciplina> di)
        {
            List<ListarDisciplina> ret = new List<ListarDisciplina>();
            foreach (Libreria.LogicaNegocio.Entidades.Disciplina disciplina in di)
            {
                ListarDisciplina dtoDisciplina = new ListarDisciplina();
                dtoDisciplina.Id = disciplina.Id;
                dtoDisciplina.Nombre = disciplina.Nombre;
                dtoDisciplina.AnoDeIntegracion = disciplina.AnoDeIntegracion;
                ret.Add(dtoDisciplina);
            }
            return ret;
        }



        /*Editar disciplina*/

        public static Libreria.LogicaNegocio.Entidades.Disciplina FromDisciplinaModificacionDto(EditarDisciplinaDTO editDis)
        {
            return new Libreria.LogicaNegocio.Entidades.Disciplina(editDis.Id, editDis.Nombre, editDis.AnoDeIntegracion);
        }




    }
}
