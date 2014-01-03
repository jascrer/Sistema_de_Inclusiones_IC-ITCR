
#region Acerca de...
/////////////////////////////////////////////////////////////////////////////
//  Instituto Tecnológico de Costa Rica
//  Proyecto: Inclutec - Sistema Automatizado de Inclusiones
//  Descripción: Clase que publica los metodos para el Estudiante.
//  Generado por ITCR Gen v1.0.0.0 
//  Fecha: Lunes, 30 de Diciembre de 2013, 2:20:00 p.m.
////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

#region Librerias Inclutec
using ITCR.Ado.ClasesComunes;
using ITCR.Ado.ModeloAcDatos;
using ITCR.MetodosAccesoDatos.Interfaces;
#endregion

namespace ITCR.MetodosAccesoDatos.Clases
{
    public class MetodosEstudiante : IMetodosEstudiante
    {
        #region Atributos
        wsDar.AdmisionyRegistro _objConexionWS;
        Inclutec_BDEntities _objConexionBase;
        #endregion

        #region Constructores
        #endregion

        #region Metodos
        /**
         * Retorna los datos del Estudiante especificado mediante el Carnet
         **/
        public Estudiante ObtenerDatosEstudiante(string pCarnet) 
        {
            _objConexionWS = new wsDar.AdmisionyRegistro();
           
            DataSet _dsDatosEstudiante = _objConexionWS.IESCDATOSESTUDIANTE_Buscar(pCarnet);
            DataRow _drEstudiante = _dsDatosEstudiante.Tables[0].Rows[0];

            DataSet _dsDatosPlanEstudiante = _objConexionWS.DATOS_ESTUDIANTE(pCarnet);
            DataRow _drPlanEstudiante = _dsDatosPlanEstudiante.Tables[0].Rows[0];

            String[] _strNombreEstudiante = _drEstudiante["NOM_ESTUDIANTE"].ToString().Split(' ');

            Estudiante _estEstudiante = new Estudiante();
            _estEstudiante.Id_Carnet = _drEstudiante["IDE_ESTUDIANTE"].ToString();
            _estEstudiante.Nom_Nombre = _strNombreEstudiante[2];
            if (_strNombreEstudiante.Length == 4)
            {
                _estEstudiante.Nom_Nombre += " " + _strNombreEstudiante[3];
            }
            _estEstudiante.Txt_Apellido1 = _strNombreEstudiante[0];
            _estEstudiante.Txt_Apellido2 = _strNombreEstudiante[1];
            _estEstudiante.Num_Telefono = _drEstudiante["NUM_TELEFONO"].ToString();
            _estEstudiante.Num_Celular = _drEstudiante["NUM_CELULAR"].ToString();
            _estEstudiante.Dir_Email = _drEstudiante["DIR_CORREO"].ToString();
            _estEstudiante.Num_Plan_Estudios = Int32.Parse(_drPlanEstudiante["IDE_PLAN"].ToString());

            return _estEstudiante;
        }

        /**
         * Retorna los cursos matriculados del _sifeEstudiante
         **/
        public LinkedList<string> ObtenerCursosEstudiante(string pCarnet, string pModalidad)
        {

            return null;
        }


        /**
         * Retorna la lista con los grupos a los que se le puede hacer inclusion
         **/
        public LinkedList<string> ObtenerGruposParaInclusion(string pCarnet)
        {
            return null;
        }

        /**
         * Retorna las solicitudes hechas por el _sifeEstudiante
         **/
        public LinkedList<string> ObtenerSolicitudesEstudiante(string pCarnet)
        {
            return null;
        }

        /**
         * Retorna los grupos especificados en una inclusion
         **/
        public LinkedList<string> ObtenerGruposInclusion(Solicitud pSolicitud)
        {
            return null;
        }

        /**
         * Guarda los datos del Estudiante en la base de datos
         **/
        public bool GuardarDatosEstudiantes(Estudiante pEstudiante)
        {
            try 
            {
                _objConexionBase = new Inclutec_BDEntities();

                var _Verificacion = from _sifEstudiantes in _objConexionBase.SIFEstudiantes
                                    where _sifEstudiantes.id_Carnet == pEstudiante.Id_Carnet
                                    select _sifEstudiantes;

                if (_Verificacion.Count() == 0)
                {
                    SIFEstudiante _sifeEstudiante = new SIFEstudiante();
                    _sifeEstudiante.id_Carnet = pEstudiante.Id_Carnet;
                    _sifeEstudiante.nom_nombre = pEstudiante.Nom_Nombre;
                    _sifeEstudiante.txt_apellido_1 = pEstudiante.Txt_Apellido1;
                    _sifeEstudiante.txt_apellido_2 = pEstudiante.Txt_Apellido2;
                    _sifeEstudiante.num_telefono = pEstudiante.Num_Telefono;
                    _sifeEstudiante.num_celular = pEstudiante.Num_Celular;
                    _sifeEstudiante.dir_email = pEstudiante.Dir_Email;
                    _sifeEstudiante.num_plan_estudios = pEstudiante.Num_Plan_Estudios;

                    _objConexionBase.AddToSIFEstudiantes(_sifeEstudiante);
                    _objConexionBase.SaveChanges();

                }

                _objConexionBase.Connection.Close();

                return true;
            }catch (Exception) {
                return false;
            }
        }

        /**
         * Guarda la solicitud creada por el _sifeEstudiante
         **/
        public bool GuardarSolicitud(string pEstudiante, int pPeriodo, 
            Solicitud pSolicitud)
        {
            try
            {
                _objConexionBase = new Inclutec_BDEntities();

                SIFSolicitud _sifSolicitud = new SIFSolicitud();
                _sifSolicitud.id_Solicitud = _objConexionBase.SIFSolicituds.Count();
                _sifSolicitud.txt_comentario = pSolicitud.Txt_Comentario;
                _sifSolicitud.txt_curso = pSolicitud.Id_Curso;
                _sifSolicitud.txt_estado = pSolicitud.Txt_Estado;
                _sifSolicitud.txt_motivo = pSolicitud.Txt_Motivo;
                _sifSolicitud.FK_Estudiante_carnet = pEstudiante;
                _sifSolicitud.FK_Periodo_idPeriodo = pPeriodo;

                _objConexionBase.Connection.Close();
                return true;
            }catch (Exception)
            {
                return false;
            }
        }

        /**
         * Modifica los grupos especificados en una solicitud
         **/
        public bool ModificiarSolicitud(Solicitud pSolicitud)
        {
            _objConexionBase = new Inclutec_BDEntities();
            


            return true;
        }

        /**
         * Anula la solicitud especificada
         **/
        public bool AnularSolicitud(Solicitud pSolicitud)
        {
            try
            {
                _objConexionBase = new Inclutec_BDEntities();

                SIFSolicitud _sifSolicitud = (from _sifSolicitudes in _objConexionBase.SIFSolicituds
                                              where _sifSolicitudes.id_Solicitud == pSolicitud.Id_Solicitud
                                              select _sifSolicitudes).First();
                _sifSolicitud.txt_estado = _sifSolicitud.txt_estado;

                _objConexionBase.SaveChanges();
                _objConexionBase.Connection.Close();
                return true;
            }
            catch (Exception)
            {
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
