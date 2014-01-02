
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase que publica los servicios web para el login de la aplicacion.
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Lunes, 30 de Diciembre de 2013, 1:00:00 p.m.
////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ITCR.MetodosAccesoDatos.Interfaces;

namespace ITCR.MetodosAccesoDatos.Clases
{
    public class MetodosLogin : IMetodosLogin
    {     
        #region Atributos
        #endregion

        #region Constructores
        #endregion

        #region Metodos
        /**
         * Metodo que devuelve si la combinacion carne y pin
         * existe en la base de datos.
         **/
        public bool VerificarEstudiante(string pUsuario, string pPassword, int FuncionarioEstudiante)
        {
            wsDar.AdmisionyRegistro _objConexionDar = new wsDar.AdmisionyRegistro();

            switch(FuncionarioEstudiante){
                case 0:
                    return _objConexionDar.ESTUDIANTE_EXISTE(pUsuario, pPassword);
                case 1:
                    return _objConexionDar.FUNCIONARIO_EXISTE(pUsuario, pPassword);
                default:
                    return false;
            }
        }
        #endregion

        #region Constantes
        #endregion

        #region Propiedades
        #endregion
    }
}
