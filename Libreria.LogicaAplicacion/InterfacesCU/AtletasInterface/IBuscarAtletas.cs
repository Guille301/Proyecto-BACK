﻿using Compartido.DTOS.Atleta;
using Compartido.DTOS.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCU.AtletasInterface
{
    public interface IBuscarAtletas
    {

        AtletaDatosCompletosDto Ejecutar(int id);



    }
}