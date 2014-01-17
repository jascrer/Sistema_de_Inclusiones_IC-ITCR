
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
            return _metEstudiante.GuardarDatosEstudiantes(pEstudiante,pPlanEstudios);
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
            return _metEstudiante.ObtenerCursosEstudiante("","");
        }
        #endregion

        #region Propiedades
        #endregion
    }
}
