using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;

namespace Libreria.Acceso.Datos.Repositorio.EF
{
    public class RepositorioAuditoriaEF : IRepositorioAuditoria
    {
        private readonly LibreriaContext _db;

        public RepositorioAuditoriaEF(LibreriaContext db)
        {
            _db = db;
        }

        public void Add(Auditoria auditoria)
        {
            try
            {
                _db.Auditorias.Add(auditoria);
                _db.SaveChanges(); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la auditoría", ex);
            }
        }
    }
}

