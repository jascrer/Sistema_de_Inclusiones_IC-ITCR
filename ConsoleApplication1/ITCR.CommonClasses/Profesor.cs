#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase entidad para la tabla SIFExcepcion
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Viernes, 4 de Enero de 2014, 03:15:00 p.m.
////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITCR.Ado.ClasesComunes
{
    class Profesor
    {
        #region Propiedades

        /// <summary>
        /// Identificador de profesor
        /// </summary>
        public string Id_Profesor { get; set; }

        /// <summary>
        /// Nombre de profesor
        /// </summary>
        public string Txt_Nombre { get; set; }

        /// <summary>
        /// Correo electrónico del profesor
        /// </summary>
        public string Txt_Email { get; set; }

        #endregion
    }
}
