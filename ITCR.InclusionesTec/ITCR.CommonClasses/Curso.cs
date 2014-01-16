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

using System.Runtime.Serialization;

namespace ITCR.Ado.ClasesComunes
{
    [DataContract]
    public class Curso
    {
        #region Propiedades

        /// <summary>
        /// Identificador del curso
        /// </summary>
        [DataMember]
        public int Id_Curso { get; set; }

        /// <summary>
        /// Código del curso
        /// </summary>
        [DataMember]
        public string Cod_Curso { get; set; }

        /// <summary>
        /// Nombre del curso
        /// </summary>
        [DataMember]
        public string Txt_Curso { get; set; }

        #endregion
    }
}
