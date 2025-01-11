using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Acceso.Datos.Repositorio.Listas
{
    public class RepositorioAtletaMemoria
    {

        private static List<Atleta> _atletas = new List<Atleta>();

        public IEnumerable<Atleta> FindAll()
        {
            return _atletas;

        }



        public Atleta FindById(int id)
        {
            Atleta atletaBuscado = null;

            foreach (Atleta u in _atletas)
            {
                if (u.Id == id)
                {
                    atletaBuscado = u;
                    return atletaBuscado;
                }
            }
            throw new NotImplementedException($"No existe el usuario id {id}");
        }



















    }
}
