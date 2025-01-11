using Compartido.DTOS.Mappers;
using Compartido.DTOS.Auditoria;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaNegocio.Entidades;
using System;
using Libreria.LogicaAplicacion.InterfacesCU.AuditoriaInterface;

namespace Libreria.LogicaNegocio.CasosDeUso
{
    public class RegistrarAuditoria : IRegistrarAuditoria
    {
        private readonly IRepositorioAuditoria _repositorioAuditoria;

        public RegistrarAuditoria(IRepositorioAuditoria repositorioAuditoria)
        {
            _repositorioAuditoria = repositorioAuditoria;
        }

        public void Ejecutar(AuditoriaDto auditoriaDto)
        {

            var auditoria = new Auditoria
            {
                Operacion = auditoriaDto.Operacion,
                Entidad = auditoriaDto.Entidad,
                EntidadId = auditoriaDto.EntidadId,
                Fecha = auditoriaDto.Fecha,
                UsuarioEmail = auditoriaDto.UsuarioEmail
            };

            _repositorioAuditoria.Add(auditoria);
        }
    }
}