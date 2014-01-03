
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase entidad para la tabla SIFEstudiante
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Domingo, 12 de Diciembre de 2013, 10:50:00 a.m.
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
    public class Estudiante
    {
        #region Propiedades

        /// <summary>
        /// Corresponde al identificador del estudiante
        /// </summary>
        [DataMember]
        public string Id_Carnet { get; set; }

        /// <summary>
        /// Corresponde al nombre del estudiante
        /// </summary>
        [DataMember]
        public string Nom_Nombre { get; set; }

        /// <summary>
        /// Corresponde al primer apellido del estudiante
        /// </summary>
        [DataMember]
        public string Txt_Apellido1 { get; set; }

        /// <summary>
        /// Corresponde al segundo apellido del estudiante
        /// </summary>
        [DataMember]
        public string Txt_Apellido2 { get; set; }

        /// <summary>
        /// Corresponde al numero de telefono del estudiante
        /// </summary>
        [DataMember]
        public string Num_Telefono { get; set; }

        /// <summary>
        /// Corresponde al numero de celular del estudiante
        /// </summary>
        [DataMember]
        public string Num_Celular { get; set; }

        /// <summary>
        /// Corresponde al email del estudiante
        /// </summary>
        [DataMember]
        public string Dir_Email { get; set; }

        /// <summary>
        /// Corresponde al plan de estudios del estudiante
        /// </summary>
        [DataMember]
        public int Num_Plan_Estudios { get; set; }

        #endregion
    }
}
