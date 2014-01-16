
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase define y publica los servicios web para el login de la aplicacion.
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

using ITCR.MetodosAccesoDatos.Interfaces;
using ITCR.MetodosAccesoDatos.Clases;

namespace ITCR.RestServiciosWebDatos
{
    public class RestServicioLogin : IRestServicioLogin
    {
        #region Atributos
        #endregion

        #region Constructores
        #endregion

        #region Metodos

        /**
         * Recibe el Carnet y Pin del Estudiante y verifica si existe en la
         * base de datos del Departamento de Admision y Registro mediante
         * los servicio wsDAR.
         **/
        public bool VerificarEstudiante(string pCarne, string pPin)
        {
            IMetodosLogin _metLogin = new MetodosLogin();
            return _metLogin.VerificarUsuario(pCarne,pPin,0);
        }

        #endregion

        #region Propiedades
        #endregion
    }
}
