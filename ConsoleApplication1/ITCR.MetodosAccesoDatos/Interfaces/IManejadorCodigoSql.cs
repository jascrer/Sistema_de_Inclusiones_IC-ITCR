
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Interfaz que publica metodos para ejecutar 
//  codigo sql en la base de datos
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Domingo, 12 de Enero de 2014, 4:30:00 p.m.
////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITCR.MetodosAccesoDatos.Interfaces
{
    public interface IManejadorCodigoSql
    {
        /// <summary>
        /// Crea un procedimiento almacenado en la base de datos
        /// </summary>
        /// <param name="pParametros"></param>
        /// <param name="pConnectionString"></param>
        void CrearProcedimiento(string pProcedimiento);

        /// <summary>
        /// Recibe codigo sql y modifica el procedimiento en la base de datos
        /// </summary>
        /// <param name="pParametros">Debe iniciar con Alter Procedure</param>
        /// <param name="pConnectionString"></param>
        void ModificarProcedimiento(string pProcedimiento);

    }
}
