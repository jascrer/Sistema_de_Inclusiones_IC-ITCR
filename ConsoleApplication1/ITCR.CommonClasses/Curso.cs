#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase entidad para la tabla SIFCurso
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Viernes, 3 de Enero de 2014, 09:58:00 a.m.
////////////////////////////////////////////////////////////////////////////
#endregion


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITCR.Ado.ClasesComunes
{
    class Curso
    {
        #region Propiedades

        /// <summary>
        /// Identificador del curso
        /// </summary>
        public int Id_Curso { get; set; }

        /// <summary>
        /// Código del curso
        /// </summary>
        public string Cod_Curso { get; set; }

        /// <summary>
        /// Nombre del curso
        /// </summary>
        public string Txt_Curso { get; set; }

        #endregion
    }
}
