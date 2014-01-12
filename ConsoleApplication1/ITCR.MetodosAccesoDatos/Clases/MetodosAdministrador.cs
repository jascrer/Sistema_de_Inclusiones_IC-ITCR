#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase que publica los metodos para el Administrador.
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Lunes, 30 de Diciembre de 2013, 2:20:00 p.m.
////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

#region Librerias Inclutec
using ITCR.Ado.ClasesComunes;
using ITCR.Ado.ModeloAcDatos;
using ITCR.MetodosAccesoDatos.Interfaces;
#endregion

namespace ITCR.MetodosAccesoDatos.Clases
{
    public class MetodosAdministrador : IMetodosAdministrador
    {
        #region Atributos
        wsDar.AdmisionyRegistro _objConexionWS;
        Inclutec_BDEntities _objConexionBase;
        #endregion

        #region Constructores
        #endregion

        #region Metodos
        /**
         * Devuelve la lista de solicitudes del periodo.
         **/
        public LinkedList<string> ObtenerReporteSolicitudes()
        {
            return null;
        }

        /**
         * Devuelve la lista de sugerencias para nuevos grupos.
         **/
        public LinkedList<string> ObtenerReporteSugerencias()
        {
            return null;
        }
        /**
         * Define un periodo para la aceptacion de solicitudes.
         **/
        public bool DefinirPeriodoSolicitud(Periodo pPeriodo)
        {
            try
            {
                SIFPeriodo _sifPeriodo = new SIFPeriodo();
                _sifPeriodo.fec_fin = pPeriodo.Fec_Fin;
                _sifPeriodo.fec_inicio = pPeriodo.Fec_Inicio;
                _sifPeriodo.num_anno = pPeriodo.Num_Anno;
                _sifPeriodo.num_periodo = pPeriodo.Num_Periodo;
                _sifPeriodo.txt_estado = pPeriodo.Txt_Estado;
                _sifPeriodo.txt_modalidad = pPeriodo.Txt_Modalidad;

                _objConexionBase = new Inclutec_BDEntities();
                _objConexionBase.AddToSIFPeriodoes(_sifPeriodo);
                _objConexionBase.SaveChanges();
                _objConexionBase.Connection.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /**
         * Modifica el estado del periodo.
         **/
        public bool ModificarEstadoPeriodo(int pPeriodo, string pEstado)
        {
            try
            {
                _objConexionBase = new Inclutec_BDEntities();
                SIFPeriodo _sifPeriodo = (from _sifPeriodos in _objConexionBase.SIFPeriodoes
                                          where _sifPeriodos.id_Periodo == pPeriodo
                                          select _sifPeriodos).First();
                _sifPeriodo.txt_estado = pEstado;
                _objConexionBase.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }
        }

        /**
         * Agrega una regla al negocio.
         **/
        public bool AgregarRegla(Regla pRegla)
        {
            XmlDocument _xmlEditor = new XmlDocument();
            _xmlEditor.Load("OrdenReglas.xml");

            XmlElement _xmlElemento = _xmlEditor.CreateElement(_sNODOSXML[0]);

            //XmlAttribute _xmlAtributo = _xmlEditor.CreateAttribute();
            return true;
        }

        /**
         * Modifica el orden de las reglas establecido
         * en el archivo OrdenReglas.xml.
         **/
        public bool ModificarOrdenReglas(LinkedList<Regla> pReglas)
        {
            XmlDocument _xmlEditor = new XmlDocument();
            _xmlEditor.Load("OrdenReglas.xml");

            XmlNode _xmlNodo = _xmlEditor.DocumentElement;

            return true;
        }

        /**
         * Modifica el procedimiento de una regla del negocio.
         **/
        public bool ModificarProcedimientoRegla(Regla pNombreProcedimiento, string pProcedimiento)
        {
            return true;
        }

        /**
         * Elimina una regla del negocio.
         **/
        public bool EliminarRegla(Regla pRegla)
        {
            return true;
        }
        #endregion

        #region
        #endregion

        #region Propiedades
        #endregion
    }
}
