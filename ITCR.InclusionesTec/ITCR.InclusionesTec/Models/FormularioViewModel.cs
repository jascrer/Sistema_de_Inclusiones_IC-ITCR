#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
// Instituto Tecnológico de Costa Rica
// Proyecto: Inclutec Sistema Automatizado de Inclusiones
// Descripción: Clase de acceso a datos necesarios para el formulario
// Generado por ITCR Gen v1.0.0.0 
// Fecha: Jueves, 02 de Enero de 2014, 02:50:00 p.m.
////////////////////////////////////////////////////////////////////////////
#endregion

#region Includes Sistema
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

#region Includes Inclutec
#endregion

namespace ITCR.InclusionesTec.Models
{
    public class FormularioViewModel
    {
        #region Atributos
        public DatosEstudiante datosEstudiante {get; set;}
        public List<Curso> cursosInclusion { get; set; }
        public List<Grupo> gruposInclusion { get; set; }
        public List<Curso> cursosActuales { get; set; }
        public Solicitud solicitud { get; set; }

        #endregion
        #region Constructores
        #endregion
        #region Metodos
        #endregion
        #region Constantes
        #endregion
        #region Propiedades
        #endregion
    }
}