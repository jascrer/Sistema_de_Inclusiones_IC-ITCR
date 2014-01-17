
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Interfaz que publica los servicios web para la clase Estudiante.
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
using System.ServiceModel.Web;
using System.Runtime.Serialization;
#endregion

#region Librerias Inclutec
using ITCR.Ado.ClasesComunes;
#endregion

namespace ITCR.RestServiciosWebDatos
{
    
    [ServiceContract]
    public interface IRestServicioEstudiante
    {

        /**
         * Devuelve la informacion del estudiante al que 
         * pertenece el carnet indicado
         **/
        [OperationContract]
        [WebGet(UriTemplate = "/estudiante/?id={pId}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        Estudiante ObtenerInformacionEstudiante(string pId);

        /**
         * Devuelve el plan de estudios de un estudiante.
         **/
        [OperationContract]
        [WebGet(UriTemplate = "/plan/?id={pCarnet}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        PlanEstudios ObtenerPlanEstudios(string pCarnet);

        /**
         * Devuelve la lista de cursos del semestre
         **/
        [OperationContract]
        [WebGet(UriTemplate = "/cursos",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        LinkedList<Curso> ObtenerCursos();

        /**
         * Actualiza los datos de contacto del estudiante especificado.
         * Retorna verdadero en caso de actualizarse correctamente.
         * Retorna falso en caso contrario.
         **/
        [OperationContract]
        [WebInvoke(UriTemplate = "/estudiante", Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle=WebMessageBodyStyle.Wrapped)]
        bool ActualizarContacto(Estudiante pEstudiante, int pPlanEstudios);

        /**
         * Crea un nuevo estudiante en la base de datos.
         * Si el estudiante se creo exitosamente o 
         * ya exitia en la base de datos: retorna verdadero.
         * Si no retorna falso.
         **/
        [OperationContract]
        [WebInvoke(UriTemplate = "/estudiante/?plan={pPlanEstudios}", Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool CrearEstudiante(Estudiante pEstudiante, int pPlanEstudios);

    }
}
