using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Usuario
    {
        public Usuario()
        {

        }
        public Usuario(string email, string contraseña, string rol)
        {
            Email = email;
            Contraseña = contraseña;
            Rol = rol;
            FechaCreacion = DateTime.Now; // Se asigna automáticamente al crearse
            Validar();
        }

        public Usuario(int id, string email, string contraseña, string rol)
        {
            Id = id;
            Email = email;
            Contraseña = contraseña;
            Rol = rol;
            FechaCreacion = DateTime.Now; // Se asigna automáticamente al crearse
            Validar();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CreadoPor { get; set; }


        public void Validar()
        {

            ValidarEmail(Email);
            ValidarPassword(Contraseña);
            ValidarRol(Rol);
        }
        public void ValidarPassword(string password)
        {
            if (string.IsNullOrEmpty(password.Trim()))
            {
                throw new ExcepcionesPersonalizadas.Usuarios.UsuarioException("El password no puede ser vacío");
            }

            if (password.Length < 6)
            {
                throw new ExcepcionesPersonalizadas.Usuarios.UsuarioException("Largo de la password insuficiente");
            }

            if (!password.Any(char.IsUpper))
            {
                throw new ExcepcionesPersonalizadas.Usuarios.UsuarioException("El password debe contener al menos una letra mayúscula");
            }

            if (!password.Any(char.IsLower))
            {
                throw new ExcepcionesPersonalizadas.Usuarios.UsuarioException("El password debe contener al menos una letra minúscula");
            }

            if (!password.Any(char.IsDigit))
            {
                throw new ExcepcionesPersonalizadas.Usuarios.UsuarioException("El password debe contener al menos un dígito");
            }

            if (!password.Any(c => ".;,!".Contains(c)))
            {
                throw new ExcepcionesPersonalizadas.Usuarios.UsuarioException("El password debe contener al menos un carácter de puntuación (. , ; !)");
            }
        }
        public void ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email.Trim()))
            {
                throw new ExcepcionesPersonalizadas.Usuarios.UsuarioException("El email no puede ser vacío");
            }

            email = email.Trim().ToLower();

            if (!email.EndsWith("@gmail.com"))
            {
                throw new ExcepcionesPersonalizadas.Usuarios.UsuarioException("El email debe terminar en @gmail.com");
            }
        }
        public void ValidarRol(string rol)
        {

            if (string.IsNullOrEmpty(rol.Trim()))
            {
                throw new ExcepcionesPersonalizadas.Usuarios.UsuarioException("El rol no puede ser vacío");
            }
            if (rol != "Administrador"
                && rol != "Digitador")
            {
                throw new ExcepcionesPersonalizadas.Usuarios.UsuarioException("El rol no es válido");
            }
        }

    }
}
