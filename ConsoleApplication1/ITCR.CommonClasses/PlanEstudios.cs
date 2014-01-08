﻿#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase entidad para la tabla SITExcepcion
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Viernes, 4 de Enero de 2014, 03:36:00 p.m.
////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITCR.Ado.ClasesComunes
{
    public class PlanEstudios
    {
        #region Propiedades

        /// <summary>
        /// Corresponde al identificador de plan de estudios
        /// </summary>
        public int Id_Plan_Estudios { get; set; }

        /// <summary>
        /// Corresponde al nombre de la carrera
        /// </summary>
        public string Nom_Carrera { get; set; }

        #endregion
    }
}