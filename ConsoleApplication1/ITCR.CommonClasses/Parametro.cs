
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase que representa los parametros de los stored procedures
//               de la regla de negocio.
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Sabado, 11 de Enero de 2014, 6:00:00 p.m.
////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITCR.Ado.ClasesComunes
{
    public class Parametro
    {        
        #region Atributos
        /// <summary>
        /// Nombre del parametro.
        /// </summary>
        string _sNombre;

        /// <summary>
        /// Tipo del parametro.
        /// </summary>
        string _sTipo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase que solo define el nombre.
        /// </summary>
        /// <param name="pNombre"></param>
        public Parametro(string pNombre)
        {
            _sNombre = pNombre;
            _sTipo = null;
        }

        /// <summary>
        /// Constructor de la clase que define el nombre y el tipo
        /// del parametro.
        /// </summary>
        /// <param name="pNombre"></param>
        /// <param name="pTipo"></param>
        public Parametro(string pNombre, string pTipo)
        {
            _sNombre = pNombre;
            _sTipo = pTipo;
        }
        #endregion

        #region Metodos
        #endregion

        #region Propiedades
        /// <summary>
        /// Retorna y modifica el nombre del parametro.
        /// </summary>
        public string Nombre
        {
            get
            {
                return _sNombre;
            }
            set
            {
                _sNombre = value;
            }

        }

        /// <summary>
        /// Retorna y modifica el tipo del parametro.
        /// </summary>
        public string Tipo
        {
            get
            {
                return _sTipo;
            }
            set
            {
                _sTipo = value;
            }
        }
        #endregion
    }
}
