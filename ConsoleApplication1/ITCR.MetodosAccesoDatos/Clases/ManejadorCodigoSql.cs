
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase que ejecuta codigo sql en la base de datos
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Domingo, 12 de Enero de 2014, 4:30:00 p.m.
////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region Added Libraries
using System.IO;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
#endregion

using ITCR.MetodosAccesoDatos.Interfaces;

namespace ITCR.MetodosAccesoDatos.Clases
{
    public class ManejadorCodigoSql : IManejadorCodigoSql
    {      
        #region Atributos
        #endregion

        #region Constructores
        #endregion

        #region Metodos
        /// <summary>
        /// Crea un procedimiento almacenado en la base de datos
        /// </summary>
        /// <param name="pProcedimiento"></param>
        /// <param name="pConnectionString"></param>
        public void CrearProcedimiento(string pProcedimiento, string pConnectionString)
        {
        } 

        /// <summary>
        /// Recibe codigo sql y modifica el procedimiento en la base de datos
        /// </summary>
        /// <param name="pProcedimiento">Debe iniciar con Alter Procedure</param>
        /// <param name="pConnectionString"></param>
        public void ModificarProcedimiento(string pProcedimiento, string pConnectionString)
        {
        }

        /// <summary>
        /// Elimina un procedimiento almacenado.
        /// </summary>
        /// <param name="pNombreProcedimiento"></param>
        /// <param name="pConnectionString"></param>
        public void EliminarProcedimiento(string pNombreProcedimiento, string pConnectionString)
        {
        }
        #endregion

        #region Propiedades
        #endregion
    }
}
