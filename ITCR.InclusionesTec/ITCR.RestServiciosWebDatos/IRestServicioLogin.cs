
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Interfaz que publica los servicios web para el login de la aplicacion.
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Lunes, 30 de Diciembre de 2013, 10:00:00 a.m.
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

namespace ITCR.RestServiciosWebDatos
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRestServicioLogin" in both code and config file together.
    [ServiceContract]
    public interface IRestServicioLogin
    {
        /**
         * Recibe el Carnet y Pin del Estudiante y verifica si existe en la
         * base de datos del Departamento de Admision y Registro mediante
         * los servicio wsDAR.
         **/
        [OperationContract]
        [WebGet(UriTemplate = "/login/?carne={pCarne}&pin={pPin}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool VerificarEstudiante(string pCarne, string pPin);

    }
}
