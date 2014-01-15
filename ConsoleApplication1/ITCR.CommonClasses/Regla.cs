
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase que representa las reglas de negocio.
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
    public class Regla
    {
        #region Atributos
        /// <summary>
        /// Indica la prioridad de la regla.
        /// </summary>
        int _iPosicion;

        /// <summary>
        /// Indica el nombre de la regla.
        /// </summary>
        string _sNombre;

        /// <summary>
        /// Indica el nombre de la regla.
        /// </summary>
        string _sStoredProcedure;

        /// <summary>
        /// Representa el estado de la regla.
        /// </summary>
        string _sEstado;

        /// <summary>
        /// Lista de parametros del procedure.
        /// </summary>
        LinkedList<Parametro> _liParametros;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="pPosicion"></param>
        /// <param name="pNombre"></param>
        /// <param name="pStoredProcedure"></param>
        public Regla(int pPosicion, string pNombre, string pStoredProcedure)
        {
            _iPosicion = pPosicion;
            _sNombre = pNombre;
            _sStoredProcedure = pStoredProcedure;
            _liParametros = new LinkedList<Parametro>();

        }
        #endregion

        #region Metodos
        /// <summary>
        /// Inserta un parametro para el procedure.
        /// </summary>
        /// <param name="pNombre"></param>
        public void InsertarParametro(string pNombre)
        {
            Parametro _paramElemento = new Parametro(pNombre);
            _liParametros.AddLast(_paramElemento);
        }

        /// <summary>
        /// Inserta un parametro para el procedure.
        /// </summary>
        /// <param name="pNombre"></param>
        /// <param name="pTipo"></param>
        public void InsertarParametro(string pNombre, string pTipo)
        {
            Parametro _paramElemento = new Parametro(pNombre, pTipo);
            _liParametros.AddLast(_paramElemento);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Retorna y modifica la prioridad de la regla.
        /// </summary>
        public int Posicion 
        {
            get
            {
                return _iPosicion;
            }
            set
            {
                _iPosicion = value;
            }
        }

        /// <summary>
        /// Retorna y modifica el nombre de la regla.
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
        /// Retorna y modifica el nombre de la regla.
        /// </summary>
        public string StoredProcedure 
        {
            get
            {
                return _sStoredProcedure;
            }
            set
            {
                _sStoredProcedure = value;
            }
        }

        /// <summary>
        /// Retorna y modifica el estado de la regla.
        /// </summary>
        public string Estado
        {
            get
            {
                return _sEstado;
            }
            set
            {
                _sEstado = value;
            }
        }

        /// <summary>
        /// Retorna la lista de parametros del procedure
        /// </summary>
        public LinkedList<Parametro> Parametros
        {
            get
            {
                return _liParametros;
            }
        }
        #endregion
    }
}
