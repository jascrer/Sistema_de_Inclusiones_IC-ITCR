
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase define y publica los servicios web para la clase Estudiante.
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Domingo, 29 de Diciembre de 2013, 5:50:00 p.m.
////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

#region Added Libraries
using System.ServiceModel;
using System.ServiceModel.Activation;
#endregion

#region Librerias Inclutec
using ITCR.Ado.ClasesComunes;
using ITCR.MetodosAccesoDatos.Clases;
using ITCR.MetodosAccesoDatos.Interfaces;
#endregion

namespace ITCR.RestServiciosWebDatos
{

    public class RestServicioEstudiante : IRestServicioEstudiante
    {

        #region Atributos
        #endregion

        #region Constructores
        #endregion

        #region Metodos

        /**
         * Crea un nuevo estudiante en la base de datos.
         * Si el estudiante se creo exitosamente o 
         * ya exitia en la base de datos: retorna verdadero.
         * Si no retorna falso.
         **/
        public bool CrearEstudiante(Estudiante pEstudiante, int pPlanEstudios)
        {
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            return _metEstudiante.GuardarDatosEstudiantes(pEstudiante, pPlanEstudios);
        }

        /**
         * Devuelve la informacion del estudiante al que 
         * pertenece el carnet indicado
         **/
        public Estudiante ObtenerInformacionEstudiante(string pId)
        {
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            return _metEstudiante.ObtenerDatosEstudiante(pId, _metEstudiante.EstudianteExiste(pId));
        }

        /**
        * Devuelve el plan de estudios de un estudiante.
        **/
        public PlanEstudios ObtenerPlanEstudios(string pCarnet)
        {
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            return _metEstudiante.ObtenerPlanEstudios(pCarnet, _metEstudiante.EstudianteExiste(pCarnet));
        }

        /**
         * Devuelve un string con la cita de matricula
         **/
        public string ObtenerCitaMatricula(string pCarnet)
        {
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            return _metEstudiante.ObtenerCitaMatricula(pCarnet);
        }

        /**
         * Actualiza los datos de contacto del estudiante especificado.
         * Retorna verdadero en caso de actualizarse correctamente.
         * Retorna falso en caso contrario.
         **/
        public bool ActualizarContacto(Estudiante pEstudiante, int pPlanEstudios)
        {
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            return _metEstudiante.GuardarDatosEstudiantes(pEstudiante, pPlanEstudios);
        }

        /**
         * Devuelve la lista de cursos del semestre
         **/
        public LinkedList<Curso> ObtenerCursos()
        {
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            //Temporalmente tiene "" como parametros.
            return _metEstudiante.ObtenerCursosEstudiante("", "");
        }

        #region Obtener Solicitudes
        /**
         * Devuelve las solicitudes pendientes.
         **/
        public LinkedList<Solicitud> ObtenerSolicitudesPendientes(string pCarnet, int pPeriodo)
        {
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            return _metEstudiante.ObtenerSolicitudesPendientes(pCarnet, pPeriodo);
        }

        /**
         * Devuelve las solicitudes anuladas.
         **/
        public LinkedList<Solicitud> ObtenerSolicitudesAnuladas(string pCarnet, int pPeriodo)
        {
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            return _metEstudiante.ObtenerSolicitudesAnuladas(pCarnet, pPeriodo);
        }

        /**
         * Devuelve las solicitudes aprobadas.
         **/
        public LinkedList<Solicitud> ObtenerSolicitudesAprobadas(string pCarnet, int pPeriodo)
        {
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            return _metEstudiante.ObtenerSolicitudesAprobadas(pCarnet, pPeriodo);
        }

        /**
         * Devuelve las solicitudes reprobadas.
         **/
        public LinkedList<Solicitud> ObtenerSolicitudesReprobadas(string pCarnet, int pPeriodo)
        {
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            return _metEstudiante.ObtenerSolicitudesReprobadas(pCarnet, pPeriodo);
        }
        #endregion

        /**
         * Devuelve el periodo
         **/
        public Periodo ObtenerPeriodo()
        {
            IMetodosAdministrador _metAdmin = new MetodosAdministrador();
            return _metAdmin.UltimoPeriodo();
        }

        /**
         * Anula la solicitud especificada
         **/
        public bool AnularSolicitud(Solicitud pSolicitud)
        {
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            return _metEstudiante.AnularSolicitud(pSolicitud);
        }

        /**
         * Crea una nueva solicitud en la base de datos
         **/
        public bool GuardarSolicitud(string pEstudiante, int pPeriodo, Solicitud pSolicitud)
        {
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            IMetodosAdministrador _metAdmin = new MetodosAdministrador();
            Periodo _perUltimo = _metAdmin.UltimoPeriodo();

            pSolicitud.Txt_Estado = "PENDIENTE";

            if ((_perUltimo.Fec_Inicio <= pSolicitud.Fec_Creacion) &&
                (_perUltimo.Fec_Fin >= pSolicitud.Fec_Creacion))
            {
                _metEstudiante.GuardarSolicitud(pEstudiante, pPeriodo, pSolicitud);
                return true;
            }
            else
            {
                return false;
            }
        }

        /**
         * Guarda la relacion entre el grupo y la solicitud
         **/
        public bool GuardarGruposSolicitud(Solicitud pSolicitud, LinkedList<Grupo> pGrupos)
        {
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            return _metEstudiante.GuardarGruposSolicitud(pSolicitud, pGrupos);
        }
        #endregion

        #region Propiedades
        #endregion
    }
}
