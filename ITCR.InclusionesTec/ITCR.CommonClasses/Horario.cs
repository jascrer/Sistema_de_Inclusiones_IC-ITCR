#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase entidad para la tabla Horario
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Viernes, 3 de Enero de 2014, 11:08:00 a.m.
////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITCR.Ado.ClasesComunes
{
    public class Horario
    {        
        #region Atributos
        #endregion

        #region Constructores
        #endregion

        #region Metodos
        #endregion

        #region Propiedades

        /// <summary>
        /// Corresponde al identificador de horario
        /// </summary>
        public int Id_Horario { get; set; }

        /// <summary>
        /// Corresponde al dia del horario
        /// </summary>
        public string Txt_Dia { get; set; }

        /// <summary>
        /// Corresponde a la hora de inicio
        /// </summary>
        public string Txt_Hora_Inicio { get; set; }

        /// <summary>
        /// Corresponde a la hora de final
        /// </summary>
        public string Txt_Hora_Final { get; set; }

        #endregion
    }
}
