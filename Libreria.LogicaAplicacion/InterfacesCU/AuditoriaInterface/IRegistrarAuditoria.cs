using Compartido.DTOS.Auditoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCU.AuditoriaInterface
{
    public interface IRegistrarAuditoria
    {
        void Ejecutar(AuditoriaDto auditoriaDto);
    }
}
