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
    public class EditarDisciplina : IEditarDisciplina
    {


        private readonly IRepositorioDisciplina _repositorioDis;
        public EditarDisciplina(IRepositorioDisciplina repositorioDis)
        {
            _repositorioDis = repositorioDis;
        }


        public void Ejecutar(EditarDisciplinaDTO editDis)
        {
 

            try
            {

                Libreria.LogicaNegocio.Entidades.Disciplina Dis = DisciplinaMappers.FromDisciplinaModificacionDto(editDis);

                if (Dis.esValido() == false)
                {
                    throw new ErrorDeDatosDisciplina("Datos no validos");
                }
                
                _repositorioDis.Update(Dis);


                

            }
            catch (ErrorDeDatosDisciplina ex)
            {
                throw new ErrorDeDatosDisciplina(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }








        }




    }
}
