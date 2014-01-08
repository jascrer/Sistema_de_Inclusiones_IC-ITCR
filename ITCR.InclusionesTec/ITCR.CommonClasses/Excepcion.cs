#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase entidad para la tabla SITExcepcion
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Viernes, 4 de Enero de 2014, 02:10:00 p.m.
////////////////////////////////////////////////////////////////////////////
#endregion


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITCR.Ado.ClasesComunes
{
    public class Excepcion
    {
        
        #region Propiedades

        /// <summary>
        /// Corresponde al identificador de excepción
        /// </summary>
        public int Id_Excepcion { get; set; }

        /// <summary>
        /// Corresponde al número de carnet del estudiante
        /// </summary>
        public string Id_Estudiante { get; set; }

        /// <summary>
        /// Corresponde al código de curso
        /// </summary>
        public int Id_Curso { get; set; }

        /// <summary>
        /// Corresponde al identificador de grupo
        /// </summary>
        public int Id_Grupo { get; set; }

        /// <summary>
        /// Corresponde al identificador del periodo
        /// </summary>
        public int Id_Periodo { get; set; }

        #endregion
    }
}
