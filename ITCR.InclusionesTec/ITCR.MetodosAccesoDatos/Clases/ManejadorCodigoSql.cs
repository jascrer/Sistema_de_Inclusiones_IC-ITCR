
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
using Microsoft.SqlServer.Management.Sdk.Sfc;
#endregion

using ITCR.MetodosAccesoDatos.Interfaces;

namespace ITCR.MetodosAccesoDatos.Clases
{
    public class ManejadorCodigoSql : IManejadorCodigoSql
    {
        #region Atributos
        /// <summary>
        /// Objeto con el que se establece
        /// conexion al servidor.
        /// </summary>
        Server _objServidor;

        /// <summary>
        /// String de conexion al servidor de la base
        /// </summary>
        SqlConnection _sConnectionString;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="pConnectionString">Corresponde al Connection String de la base de datos</param>
        public ManejadorCodigoSql(string pConnectionString)
        {
            _sConnectionString = new SqlConnection(pConnectionString);
            _objServidor = new Server(new ServerConnection(_sConnectionString));
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Crea un procedimiento almacenado en la base de datos
        /// </summary>
        /// <param name="pParametros">Debe ser un Create procedure</param>
        public void CrearProcedimiento(string pProcedimiento)
        {
            _objServidor.ConnectionContext.ExecuteNonQuery(pProcedimiento);
        } 

        /// <summary>
        /// Recibe codigo sql y modifica el procedimiento en la base de datos
        /// </summary>
        /// <param name="pParametros">Debe iniciar con Alter Procedure</param>
        public void ModificarProcedimiento(string pProcedimiento)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Retorna el string de conexion al servidor de la base
        /// </summary>
        public SqlConnection ConnectionString
        {
            get
            {
                return _sConnectionString;
            }
        }
        #endregion
    }
}
