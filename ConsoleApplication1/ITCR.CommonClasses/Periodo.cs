
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase entidad para la tabla SIFPeriodo
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
    public class Periodo
    {
        #region Propiedades

        /// <summary>
        /// Identificador del periodo
        /// </summary>
        public int Id_Periodo { get; set; }

        /// <summary>
        /// Corresponde a la fecha de inicio del Periodo
        /// </summary>
        public DateTime Fec_Inicio { get; set; }

        /// <summary>
        /// Corresponde a la fecha de finalizacion del Periodo
        /// </summary>
        public DateTime Fec_Fin { get; set; }

        /// <summary>
        /// Corresponde al estado del Periodo
        /// </summary>
        public string Txt_Estado { get; set; }

        /// <summary>
        /// Corresponde a la modalidad del Periodo
        /// </summary>
        public string Txt_Modalidad { get; set; }

        /// <summary>
        /// Corresponde al numero de annio del Periodo
        /// </summary>
        public int Num_Anno { get; set; }

        /// <summary>
        /// Corresponde al numero del Periodo
        /// </summary>
        public int Num_Periodo { get; set; }

        #endregion
    }
}
