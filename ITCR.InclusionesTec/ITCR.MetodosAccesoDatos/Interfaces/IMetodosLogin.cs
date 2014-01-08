
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Interfaz que publica los servicios web para el login de la aplicacion.
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Lunes, 30 de Diciembre de 2013, 1:00:00 p.m.
////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITCR.MetodosAccesoDatos.Interfaces
{
    public interface IMetodosLogin
    {
        /**
         * Metodo que devuelve si la combinacion carne y pin
         * existe en la base de datos.
         **/
        bool VerificarEstudiante(string pUsuario, string pPassword, int FuncionarioEstudiante);
    }
}
