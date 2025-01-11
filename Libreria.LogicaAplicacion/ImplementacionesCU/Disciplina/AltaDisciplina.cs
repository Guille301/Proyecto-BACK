using Compartido.DTOS.Disciplina;
using Compartido.DTOS.Mappers;
using Compartido.DTOS.Usuario;
using Libreria.LogicaAplicacion.InterfacesCU.DisciplinaInterface;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Disciplinas;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.Disciplina
{
    public class AltaDisciplina : IAltaDisciplina
    {

        private readonly IRepositorioDisciplina _repositorioDisciplina;


        public AltaDisciplina(IRepositorioDisciplina repoDisciplina)
        {
            _repositorioDisciplina = repoDisciplina;

        }



        public void Ejecutar(DisciplinaAltaDto AltaDDTO)
        {

            try
            {
             var disciplina = DisciplinaMappers.FromUsuarioDisciplinaDto(AltaDDTO);
            if (disciplina.esValido())
            {
                LogicaNegocio.Entidades.Disciplina usr = DisciplinaMappers.FromUsuarioDisciplinaDto(AltaDDTO);
                _repositorioDisciplina.Add(usr);
            }
            else 
            {
                throw new ErrorDeDatosDisciplina("Datos no validos");   
            }
            }
            catch(ErrorDeDatosDisciplina ex)
            {
                throw new ErrorDeDatosDisciplina(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

           

        }





















    }
}
