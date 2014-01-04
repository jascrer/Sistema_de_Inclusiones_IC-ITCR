
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase entidad para la tabla SIFEstudiante
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Domingo, 04 de Enero de 2014, 03:39:00 p.m.
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
    class DatosEstudiante
    {
        #region

        /// <summary>
        /// Corresponde al identificador de los datos del estudiante
        /// </summary>
        [DataMember]
        public int Id_Datos_Estudiante { get; set; }

        /// <summary>
        /// Corresponde a la cantidad de cursos faltantes
        /// </summary>
        [DataMember]
        public int Num_Cursos_Faltantes { get; set; }

        /// <summary>
        /// Corresponde a la cantidad de creditos actuales
        /// </summary>
        [DataMember]
        public int Num_Creditos_Actuales { get; set; }

        /// <summary>
        /// Corresponde a la cantidad de creditos actuales
        /// </summary>
        [DataMember]
        public int Num_Creditos_Actuales { get; set; }

        /// <summary>
        /// Corresponde al dia de matricula
        /// </summary>
        [DataMember]
        public string Txt_Dia_Matricula { get; set; }

        /// <summary>
        /// Corresponde a la hora de matricula
        /// </summary>
        [DataMember]
        public string Txt_Hora_Matricula { get; set; }

        #endregion
    }
}
