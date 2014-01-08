
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase de acceso al modelo de la base de datos
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Domingo, 12 de Diciembre de 2013, 10:50:00 a.m.
////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

#region Microsoft Practices Libraries
using Microsoft.Practices.EnterpriseLibrary.Caching;
#endregion

#region Librerias Inclutec
using ITCR.Ado.AccesoDatos;
using ITCR.Ado.ClasesComunes;
#endregion

namespace ITCR.Ado.ModeloAcDatos
{
    public class cModeloAccesoDatos : ITCR.Ado.AccesoDatos.cAccesoDatos
    {
        #region Atributos
        private static Object _LockObject = new Object();
        private static cModeloAccesoDatos _Instance;
        #endregion

        #region Constructores
        #endregion

        #region Metodos
        /// <summary>
        /// Metodos de acceso a la base de datos como 
        /// stored procedures
        /// </summary>
        #endregion

        #region Propiedades
        public static cModeloAccesoDatos Instance { get; set; }
        #endregion
    }
}
