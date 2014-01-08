
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
         * Retorna true si el Estudiante existe en la base de la aplicacion
         * Retorna false en caso contrario.
         **/
        public bool EstudianteExiste(string pCarnet)
        {
            _objConexionBase = new Inclutec_BDEntities();

            int _iExiste = (from _sifEstudiantes in _objConexionBase.SIFEstudiantes
                            where _sifEstudiantes.id_Carnet == pCarnet
                            select _sifEstudiantes).Count();

            _objConexionBase.Connection.Close();
            switch (_iExiste)
            {
                case 0:
                    return false;
                default:
                    return true;
            }
        }

        /**
         * Retorna los datos del Estudiante especificado mediante el Carnet
         **/
        public Estudiante ObtenerDatosEstudiante(string pCarnet, bool pExisteBase) 
        {
            Estudiante _estEstudiante = new Estudiante();

            if (pExisteBase)
            {
                _objConexionBase = new Inclutec_BDEntities();

                SIFEstudiante _sifEstudiante = (from _sifEstudiantes in _objConexionBase.SIFEstudiantes
                                                where _sifEstudiantes.id_Carnet == pCarnet
                                                select _sifEstudiantes).First();

                _objConexionBase.Connection.Close();

                _estEstudiante.Id_Carnet = _sifEstudiante.id_Carnet;
                _estEstudiante.Nom_Nombre = _sifEstudiante.nom_nombre;
                _estEstudiante.Num_Celular = _sifEstudiante.num_celular;
                _estEstudiante.Num_Telefono = _sifEstudiante.num_telefono;
                _estEstudiante.Txt_Apellido1 = _sifEstudiante.txt_apellido_1;
                _estEstudiante.Txt_Apellido2 = _sifEstudiante.txt_apellido_2;
                _estEstudiante.Dir_Email = _sifEstudiante.dir_email;

            }
            else
            {
                _objConexionWS = new wsDar.AdmisionyRegistro();

                DataSet _dsDatosEstudiante = _objConexionWS.IESCDATOSESTUDIANTE_Buscar(pCarnet);
                DataRow _drEstudiante = _dsDatosEstudiante.Tables[0].Rows[0];

                String[] _strNombreEstudiante = _drEstudiante["NOM_ESTUDIANTE"].ToString().Split(' ');

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

            }
            return _estEstudiante;
        }

        /**
         * Retorna el plan asociado al estudiante
         **/
        public PlanEstudios ObtenerPlanEstudios(string pCarnet, bool pExisteBase)
        {
            PlanEstudios _planEstudios = new PlanEstudios();

            if (pExisteBase)
            {
                _objConexionBase = new Inclutec_BDEntities();

                SIFPlanEstudio _sifPlanEstudios = (from _sifEstudiantes in _objConexionBase.SIFEstudiantes
                                                   where _sifEstudiantes.id_Carnet == pCarnet
                                                   select _sifEstudiantes.SIFPlanEstudio).First();

                _objConexionBase.Connection.Close();
                _planEstudios.Id_Plan_Estudios = _sifPlanEstudios.id_PlanEstudios;
                _planEstudios.Nom_Carrera = _sifPlanEstudios.nom_carrera;
            }
            else
            {
                DataSet _dsDatosPlanEstudiante = _objConexionWS.DATOS_ESTUDIANTE(pCarnet);
                DataRow _drPlanEstudiante = _dsDatosPlanEstudiante.Tables[0].Rows[0];

                _planEstudios.Id_Plan_Estudios = Int32.Parse(_drPlanEstudiante["IDE_PLAN"].ToString());
                _planEstudios.Nom_Carrera = _drPlanEstudiante["DSC_PLAN"].ToString();
            }

            return _planEstudios;
        }

        /**
         * Retorna los cursos matriculados del _sifeEstudiante
         **/
        public LinkedList<Curso> ObtenerCursosEstudiante(string pCarnet, string pModalidad)
        {
            _objConexionBase = new Inclutec_BDEntities();
            var _objCursosInclusion = from _sifCursos in _objConexionBase.SIFCursoes
                                      select _sifCursos;
            LinkedList<Curso> _sifCursoLista = new LinkedList<Curso>();
            foreach (SIFCurso _sifCurso in _objCursosInclusion)
            {
                Curso _curso = new Curso();
                _curso.Id_Curso = _sifCurso.id_Curso;
                _curso.Cod_Curso = _sifCurso.cod_Curso;
                _curso.Txt_Curso = _sifCurso.nom_Curso;
                _sifCursoLista.AddLast(_curso);
            }
            _objConexionBase.Connection.Close();
            return _sifCursoLista;
        }


        /**
         * Retorna la lista con los grupos a los que se le puede hacer inclusion
         **/
        public LinkedList<Grupo> ObtenerGruposParaInclusion(int pCurso)
        {
            _objConexionBase = new Inclutec_BDEntities();
            var _Grupos = from _sifGrupos in _objConexionBase.SIFGrupoes
                          where _sifGrupos.FK_Curso_idCurso == pCurso
                          select _sifGrupos;

            LinkedList<Grupo> _sifGrupoLista = new LinkedList<Grupo>();
            foreach (SIFGrupo _sifGrupo in _Grupos)
            {
                Grupo _grupo = new Grupo();
                _grupo.Id_Grupo = _sifGrupo.id_Grupo;
                _grupo.Num_Cupos = _sifGrupo.num_cupos;
                _grupo.Num_Cupos_Extra = _sifGrupo.num_cupos_extra;
                _grupo.Num_Grupo = _sifGrupo.num_grupo;

                /*var _liHorario = from _sitHorarios in _objConexionBase.AddToSITHorarios
                                 where _sitHorarios.*/
            }
            _objConexionBase.Connection.Close();
            return _sifGrupoLista;
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
        public bool GuardarDatosEstudiantes(Estudiante pEstudiante, PlanEstudios pPlanEstudios)
        {
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            if (_metEstudiante.EstudianteExiste(pEstudiante.Id_Carnet)) 
            {
                return true;
            }
            else
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
                        _sifeEstudiante.FK_PlanEstudios_idPlanEstudios = pPlanEstudios.Id_Plan_Estudios;

                        _objConexionBase.AddToSIFEstudiantes(_sifeEstudiante);
                        _objConexionBase.SaveChanges();

                    }

                    _objConexionBase.Connection.Close();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /**
         * Guarda la solicitud creada por el _sifeEstudiante
         **/
        public bool GuardarSolicitud(string pEstudiante, int pPeriodo, 
            Solicitud pSolicitud)
        {
            /*try
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
            }*/
            return true;
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
