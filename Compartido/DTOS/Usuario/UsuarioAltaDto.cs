﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Usuario
{
    public class UsuarioAltaDto : UsuarioBasicoDto
    {
        public string Contraseña { get; set; }
        public DateTime FechaAlta { get; set; }

        public int AdmAlta { get; set; }

    }
}