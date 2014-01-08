
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Interfaz que publica los metodos para el Estudiante.
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Lunes, 30 de Diciembre de 2013, 2:20:00 p.m.
////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ITCR.Ado.ClasesComunes;

namespace ITCR.MetodosAccesoDatos.Interfaces
{
    public interface IMetodosEstudiante
    {
        /**
         * Retorna true si el Estudiante existe en la base de la aplicacion
         * Retorna false en caso contrario.
         **/
        bool EstudianteExiste(string pCarnet);

        /**
         * Retorna los datos del Estudiante especificado mediante el Carnet
         **/
        Estudiante ObtenerDatosEstudiante(string pCarnet, bool pExisteBase);

        /**
         * Retorna el plan asociado al estudiante
         **/
        PlanEstudios ObtenerPlanEstudios(string pCarnet, bool pExisteBase);

        /**
         * Retorna la cita de matricula del estudiante
         **/


        /**
         * Retorna los cursos matriculados del _sifeEstudiante
         **/
        LinkedList<string> ObtenerCursosEstudiante(string pCarnet, string pModalidad);

        /**
         * Retorna la lista con los grupos a los que se le puede hacer inclusion
         **/
        LinkedList<string> ObtenerGruposParaInclusion(string pCarnet);

        /**
         * Retorna las solicitudes hechas por el _sifeEstudiante
         **/
        LinkedList<string> ObtenerSolicitudesEstudiante(string pCarnet);

        /**
         * Retorna los grupos especificados en una inclusion
         **/
        LinkedList<string> ObtenerGruposInclusion(Solicitud pSolicitud);

        /**
         * Guarda los datos del Estudiante en la base de datos
         **/
        bool GuardarDatosEstudiantes(Estudiante pEstudiante);

        /**
         * Guarda la solicitud creada por el _sifeEstudiante
         **/
        bool GuardarSolicitud(string pEstudiante, int pPeriodo, Solicitud pSolicitud);

        /**
         * Modifica los grupos especificados en una solicitud
         **/
        bool ModificiarSolicitud(Solicitud pSolicitud);

        /**
         * Anula la solicitud especificada
         **/
        bool AnularSolicitud(Solicitud pSolicitud);

    }
}
