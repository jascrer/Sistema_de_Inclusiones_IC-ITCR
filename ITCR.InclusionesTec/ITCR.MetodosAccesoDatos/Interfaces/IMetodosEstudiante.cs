
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
        #region Metodos
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
        string ObtenerCitaMatricula(string pCarnet);

        /**
         * Retorna los cursos matriculados del _sifeEstudiante
         **/
        LinkedList<Curso> ObtenerCursosEstudiante(string pCarnet, string pModalidad);

        /**
         * Retorna la lista con los grupos a los que se le puede hacer inclusion
         **/
        LinkedList<Grupo> ObtenerGruposParaInclusion(int pCurso);

        /**
         * Obtiene la solicitud especificada por el id
         **/
        Solicitud ObtenerSolicitudEspecificada(int pSolicitud);

        /**
         * Retorna las solicitudes pendientes hechas por el _sifeEstudiante
         **/
        LinkedList<Solicitud> ObtenerSolicitudesPendientes(string pCarnet, int pPeriodo);

        /**
         * Retorna las solicitudes anuladas hechas por el _sifeEstudiante
         **/
        LinkedList<Solicitud> ObtenerSolicitudesAnuladas(string pCarnet, int pPeriodo);

        /**
         * Retorna las solicitudes aprobadas hechas por el _sifeEstudiante
         **/
        LinkedList<Solicitud> ObtenerSolicitudesAprobadas(string pCarnet, int pPeriodo);

        /**
         * Retorna las solicitudes reprobadas hechas por el _sifeEstudiante
         **/
        LinkedList<Solicitud> ObtenerSolicitudesReprobadas(string pCarnet, int pPeriodo);

        /**
         * Retorna los grupos especificados en una inclusion
         **/
        LinkedList<Grupo_Por_Solicitud> ObtenerGruposInclusion(Solicitud pSolicitud);

        /**
         * Retorna el nombre del profesor asignado al grupo.
         **/
        string ObtenerProfesor(int pGrupo);

        /**
         * Guarda los datos del Estudiante en la base de datos
         **/
        bool GuardarDatosEstudiantes(Estudiante pEstudiante, int pPlanEstudios);

        /**
         * Guarda la solicitud creada por el _sifeEstudiante
         **/
        Solicitud GuardarSolicitud(string pEstudiante, int pPeriodo, Solicitud pSolicitud);

        /// <summary>
        /// Guarda los grupos de una solicitud
        /// </summary>
        /// <param name="pSolicitud"></param>
        /// <param name="pGrupos">Debe ir ordenada en cuanto a prioridad, 
        /// entre mayor la prioridad, mas antes tiene que ir el grupo</param>
        /// <returns></returns>
        bool GuardarGruposSolicitud(Solicitud pSolicitud, LinkedList<Grupo> pGrupos);

        /**
         * Modifica los grupos especificados en una solicitud
         **/
        bool ModificiarSolicitud(Solicitud pSolicitud, LinkedList<int> pEliminados);

        /**
         * Anula la solicitud especificada
         **/
        bool AnularSolicitud(Solicitud pSolicitud);
        #endregion
    }
}
