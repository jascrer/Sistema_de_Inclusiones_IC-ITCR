
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase entidad para la tabla SIFGrupo_Por_Solicitud
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
    public class Grupo_Por_Solicitud
    {
        #region Propiedades

        /// <summary>
        /// Identificador de la relacion entre grupo y solicitud
        /// </summary>
        public int Id_Grupo_Por_Solicitud { get; set; }

        /// <summary>
        /// Corresponde al numero de priodidad de Grupo_Por_Solicitud
        /// </summary>
        public int Num_Prioridad { get; set; }

        /// <summary>
        /// Corresponde al estado de Grupo_Por_Solicitud
        /// </summary>
        public string Txt_Estado { get; set; }

        /// <summary>
        /// Corresponde al grupo de Grupo_Por_Solicitud
        /// </summary>
        public Grupo Id_Grupo { get; set; }

        #endregion
    }
}
