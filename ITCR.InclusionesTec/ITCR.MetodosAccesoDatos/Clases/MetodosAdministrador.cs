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
        IXmlEditor _xmlEditor;
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
         * Retorna el ultimo periodo
         **/
        public Periodo UltimoPeriodo()
        {
            try
            {
                _objConexionBase = new Inclutec_BDEntities();
                SIFPeriodo _sifPeriodo = (from _sifPeriodos in _objConexionBase.SIFPeriodoes
                                          where _sifPeriodos.txt_estado == "En Curso"
                                          select _sifPeriodos).First();
                _objConexionBase.Connection.Close();

                Periodo _objPeriodo = new Periodo();
                _objPeriodo.Id_Periodo = _sifPeriodo.id_Periodo;
                _objPeriodo.Fec_Fin = _sifPeriodo.fec_fin;
                _objPeriodo.Fec_Inicio = _sifPeriodo.fec_inicio;
                _objPeriodo.Num_Anno = _sifPeriodo.num_anno;
                _objPeriodo.Num_Periodo = (int) _sifPeriodo.num_periodo;
                _objPeriodo.Txt_Estado = _sifPeriodo.txt_estado;
                _objPeriodo.Txt_Modalidad = _sifPeriodo.txt_modalidad;

                return _objPeriodo;
            }
            catch (Exception)
            {
                return null;
            }
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
            _xmlEditor = new XmlEditor("OrdenReglas.xml");
            _xmlEditor.AgregarRegla(pRegla);
            return true;
        }

        /**
         * Modifica el orden de las reglas establecido
         * en el archivo OrdenReglas.xml.
         **/
        public bool ModificarOrdenReglas(LinkedList<Regla> pReglas)
        {
            _xmlEditor = new XmlEditor("OrdenReglas.xml");
            _xmlEditor.ModificarPrioridadReglas(pReglas);
            return true;
        }

        /**
         * Modifica el procedimiento de una regla del negocio.
         **/
        public bool ModificarProcedimientoRegla(Regla pNombreProcedimiento, string pProcedimiento)
        {
            _xmlEditor = new XmlEditor("OrdenReglas.xml");
            _xmlEditor.ModificarProcedureRegla(pNombreProcedimiento);
            return true;
        }

        /**
         * Elimina una regla del negocio.
         **/
        public bool DesactivarRegla(Regla pRegla)
        {
            _xmlEditor = new XmlEditor("OrdenReglas.xml");
            _xmlEditor.DeshabilitarRegla(pRegla);
            return true;
        }
        
        /**
         * Retorna la informacion de todas las reglas.
         **/
        public LinkedList<Regla> ObtenerInformacionReglas()
        {
            _xmlEditor = new XmlEditor("OrdenReglas.xml");
            return _xmlEditor.ObtenerListaReglas();
        }

        /**
         * Crea una excepcion.
         **/
        public bool CrearExcepcion(int pPeriodo, int pCurso,
            int pGrupo, string pEstudiante)
        {
            try
            {
                SITExcepcion _sitExcepcion = new SITExcepcion();
                _sitExcepcion.FK_Curso_idCurso = pCurso;
                _sitExcepcion.FK_Estudiante_carnet = pEstudiante;
                _sitExcepcion.FK_Grupo_idGrupo = pGrupo;
                _sitExcepcion.FK_Periodo_idPeriodo = pPeriodo;

                _objConexionBase = new Inclutec_BDEntities();
                _objConexionBase.AddToSITExcepcions(_sitExcepcion);
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
         * Retorna la lista de excepciones del periodo
         **/
        public LinkedList<Excepcion> ObtenerListaExcepciones(int pPeriodo)
        {
            try
            {
                _objConexionBase = new Inclutec_BDEntities();
                var _sitExcepciones = from _sifExcepciones in _objConexionBase.SITExcepcions
                                        where _sifExcepciones.FK_Periodo_idPeriodo == pPeriodo
                                        select _sifExcepciones;
                _objConexionBase.Connection.Close();
                LinkedList<Excepcion> _liExcepciones = new LinkedList<Excepcion>();
                foreach (SITExcepcion _sitExcepcion in _sitExcepciones)
                {
                    Excepcion _excepcion = new Excepcion();
                    _excepcion.Id_Curso = _sitExcepcion.FK_Curso_idCurso;
                    _excepcion.Id_Estudiante = _sitExcepcion.FK_Estudiante_carnet;
                    _excepcion.Id_Excepcion = _sitExcepcion.id_Excepcion;
                    _excepcion.Id_Grupo = _sitExcepcion.FK_Grupo_idGrupo;
                    _excepcion.Id_Periodo = _sitExcepcion.FK_Periodo_idPeriodo;

                    _liExcepciones.AddLast(_excepcion);
                }


                return _liExcepciones;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Constantes
        #endregion

        #region Propiedades
        #endregion
    }
}
