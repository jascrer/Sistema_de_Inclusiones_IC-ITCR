
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase entidad para la tabla SIFSolicitud
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
    public class Solicitud
    {
        #region Propiedades

        /// <summary>
        /// Identificador de la solicitud
        /// </summary>
        public int Id_Solicitud { get; set; }

        /// <summary>
        /// Corresponde al comentario de la solicitud
        /// </summary>
        public string Txt_Comentario { get; set; }

        /// <summary>
        /// Corresponde al identificador del curso de la solicitud
        /// </summary>
        public int Id_Curso { get; set; }

        /// <summary>
        /// Corresponde al motivo de la solicitud
        /// </summary>
        public string Txt_Motivo { get; set; }

        /// <summary>
        /// Corresponde a la fecha de creacion de la solicitud
        /// </summary>
        public DateTime Fec_Creacion { get; set; }

        /// <summary>
        /// Corresponde al estado de la solicitud
        /// </summary>
        public string Txt_Estado { get; set; }

        /// <summary>
        /// Corresponde a la lista de Grupos a matricular
        /// </summary>
        public LinkedList<Grupo_Por_Solicitud> Li_Grupos { get; set; }

        /// <summary>
        /// Corresponde al grupo aceptado de la solicitud
        /// </summary>
        public int Id_GrupoAceptado { get; set; }

        #endregion
    }
}
