
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase entidad para la tabla SIFGrupo
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Domingo, 12 de Diciembre de 2013, 10:50:00 a.m.
////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITCR.Ado.ClasesComunes
{
    public class Grupo
    {
        #region Propiedades

        /// <summary>
        /// Corresponde al identificador del grupo
        /// </summary>
        public int Id_Grupo { get; set; }

        /// <summary>
        /// Corresponde al numero del grupo
        /// </summary>
        public int Num_Grupo { get; set; }

        /// <summary>
        /// Corresponde al numero de cupos del grupo
        /// </summary>
        public int Num_Cupos { get; set; }

        /// <summary>
        /// Corresponde al numero de cupos extra del grupo
        /// </summary>
        public int Num_Cupos_Extra { get; set; }

        /// <summary>
        /// Corresponde al identificador del curso al que pertenece
        /// </summary>
        public int Id_Curso { get; set; }

        /// <summary>
        /// Corresponde a los horario del grupo
        /// </summary>
        public LinkedList<Horario> Li_Horarios { get; set; }

        #endregion
    }
}
