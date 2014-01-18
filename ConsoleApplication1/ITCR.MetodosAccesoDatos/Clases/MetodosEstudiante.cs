
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
            try
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
            catch (Exception)
            {
                return false;
            }
        }

        /**
         * Retorna los datos del Estudiante especificado mediante el Carnet
         **/
        public Estudiante ObtenerDatosEstudiante(string pCarnet, bool pExisteBase)
        {
            try
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
            catch (Exception)
            {
                return null;
            }
        }

        /**
         * Retorna el plan asociado al estudiante
         **/
        public PlanEstudios ObtenerPlanEstudios(string pCarnet, bool pExisteBase)
        {
            try
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
            catch (Exception)
            {
                return null;
            }
        }

        /**
         * Retorna la cita de matricula del estudiante
         **/
        public string ObtenerCitaMatricula(string pCarnet)
        {
            _objConexionWS = new wsDar.AdmisionyRegistro();
            DataSet _dsCitasMatricula =
                _objConexionWS.CITASMATRICULA_Buscar(pCarnet, "1", "", "2013", "S", ObtenerPeriodoActual());
            return _dsCitasMatricula.Tables[0].Rows[0]["FEC_MATRICULA"].ToString();
        }

        //Obtiene el periodo actual sea el 1 o 2 del a
        private string ObtenerPeriodoActual()
        {
            switch (DateTime.Now.Month)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    return "1";
                default:
                    return "2";
            }
        }

        /**
         * Retorna los cursos matriculados del _sifeEstudiante
         * Temporalmente retorna todos los cursos de la carrera
         **/
        public LinkedList<Curso> ObtenerCursosEstudiante(string pCarnet, string pModalidad)
        {
            try
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
            catch (Exception)
            {
                return null;
            }
        }

        /**
         * Retorna la lista con los grupos a los que se le puede hacer inclusion
         **/
        public LinkedList<Grupo> ObtenerGruposParaInclusion(int pCurso)
        {
            try
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
                    _grupo.Li_Horarios = new LinkedList<Horario>();

                    //Agrega todos los horarios de ese grupo
                    var _liHorario = from _sitHorarios in _objConexionBase.SITHorarios
                                     where _sitHorarios.FK_Grupo_idGrupo == _grupo.Id_Grupo
                                     select _sitHorarios;

                    foreach (SITHorario _sitHorario in _liHorario)
                    {
                        Horario _objHorario = new Horario();
                        _objHorario.Id_Horario = _sitHorario.id_Horario;
                        _objHorario.Txt_Dia = _sitHorario.txt_dia;
                        _objHorario.Txt_Hora_Final = _sitHorario.tim_hora_fin.ToString();
                        _objHorario.Txt_Hora_Inicio = _sitHorario.tim_hora_inicio.ToString();
                        _grupo.Li_Horarios.AddLast(_objHorario);
                    }
                    _sifGrupoLista.AddLast(_grupo);
                }
                _objConexionBase.Connection.Close();
                return _sifGrupoLista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /**
         * Retorna las solicitudes hechas por el _sifeEstudiante
         * y que se encuentran pendientes.
         **/
        public LinkedList<Solicitud> ObtenerSolicitudesPendientes(string pCarnet, int pPeriodo)
        {
            try
            {
                _objConexionBase = new Inclutec_BDEntities();

                var _dataSolicitudes = from _sifSolicitudes in _objConexionBase.SIFSolicituds
                                       where _sifSolicitudes.FK_Estudiante_carnet == pCarnet
                                       && _sifSolicitudes.FK_Periodo_idPeriodo == pPeriodo
                                       && _sifSolicitudes.txt_estado == "PENDIENTE"
                                       select _sifSolicitudes;

                LinkedList<Solicitud> _liSolicitudes = new LinkedList<Solicitud>();

                foreach (SIFSolicitud _sifSolicitud in _dataSolicitudes)
                {
                    Solicitud _solicitud = new Solicitud();
                    _solicitud.Id_Solicitud = _sifSolicitud.id_Solicitud;
                    _solicitud.Fec_Creacion = _sifSolicitud.fec_creacion;
                    _solicitud.Txt_Comentario = _sifSolicitud.txt_comentario;
                    _solicitud.Txt_Estado = _sifSolicitud.txt_estado;
                    _solicitud.Txt_Motivo = _sifSolicitud.txt_motivo;
                    _solicitud.txt_Curso = _sifSolicitud.txt_curso;
                }

                _objConexionBase.Connection.Close();
                return _liSolicitudes;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /**
         * Retorna las solicitudes anuladas hechas por el _sifeEstudiante
         **/
        public LinkedList<Solicitud> ObtenerSolicitudesAnuladas(string pCarnet, int pPeriodo)
        {
            try
            {
                _objConexionBase = new Inclutec_BDEntities();

                var _dataSolicitudes = from _sifSolicitudes in _objConexionBase.SIFSolicituds
                                       where _sifSolicitudes.FK_Estudiante_carnet == pCarnet
                                       && _sifSolicitudes.FK_Periodo_idPeriodo == pPeriodo
                                       && _sifSolicitudes.txt_estado == "ANULADA"
                                       select _sifSolicitudes;

                LinkedList<Solicitud> _liSolicitudes = new LinkedList<Solicitud>();

                foreach (SIFSolicitud _sifSolicitud in _dataSolicitudes)
                {
                    Solicitud _solicitud = new Solicitud();
                    _solicitud.Id_Solicitud = _sifSolicitud.id_Solicitud;
                    _solicitud.Fec_Creacion = _sifSolicitud.fec_creacion;
                    _solicitud.Txt_Comentario = _sifSolicitud.txt_comentario;
                    _solicitud.Txt_Estado = _sifSolicitud.txt_estado;
                    _solicitud.Txt_Motivo = _sifSolicitud.txt_motivo;
                    _solicitud.txt_Curso = _sifSolicitud.txt_curso;
                }

                _objConexionBase.Connection.Close();
                return _liSolicitudes;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /**
         * Retorna las solicitudes aprobadas hechas por el _sifeEstudiante
         **/
        public LinkedList<Solicitud> ObtenerSolicitudesAprobadas(string pCarnet, int pPeriodo)
        {
            try
            {
                _objConexionBase = new Inclutec_BDEntities();

                var _dataSolicitudes = from _sifSolicitudes in _objConexionBase.SIFSolicituds
                                       where _sifSolicitudes.FK_Estudiante_carnet == pCarnet
                                       && _sifSolicitudes.FK_Periodo_idPeriodo == pPeriodo
                                       && _sifSolicitudes.txt_estado == "APROBADA"
                                       select _sifSolicitudes;

                LinkedList<Solicitud> _liSolicitudes = new LinkedList<Solicitud>();

                foreach (SIFSolicitud _sifSolicitud in _dataSolicitudes)
                {
                    Solicitud _solicitud = new Solicitud();
                    _solicitud.Id_Solicitud = _sifSolicitud.id_Solicitud;
                    _solicitud.Fec_Creacion = _sifSolicitud.fec_creacion;
                    _solicitud.Txt_Comentario = _sifSolicitud.txt_comentario;
                    _solicitud.Txt_Estado = _sifSolicitud.txt_estado;
                    _solicitud.Txt_Motivo = _sifSolicitud.txt_motivo;
                    _solicitud.txt_Curso = _sifSolicitud.txt_curso;
                }

                _objConexionBase.Connection.Close();
                return _liSolicitudes;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /**
         * Retorna las solicitudes reprobadas hechas por el _sifeEstudiante
         **/
        public LinkedList<Solicitud> ObtenerSolicitudesReprobadas(string pCarnet, int pPeriodo)
        {
            try
            {
                _objConexionBase = new Inclutec_BDEntities();

                var _dataSolicitudes = from _sifSolicitudes in _objConexionBase.SIFSolicituds
                                       where _sifSolicitudes.FK_Estudiante_carnet == pCarnet
                                       && _sifSolicitudes.FK_Periodo_idPeriodo == pPeriodo
                                       && _sifSolicitudes.txt_estado == "REPROBADA"
                                       select _sifSolicitudes;

                LinkedList<Solicitud> _liSolicitudes = new LinkedList<Solicitud>();

                foreach (SIFSolicitud _sifSolicitud in _dataSolicitudes)
                {
                    Solicitud _solicitud = new Solicitud();
                    _solicitud.Id_Solicitud = _sifSolicitud.id_Solicitud;
                    _solicitud.Fec_Creacion = _sifSolicitud.fec_creacion;
                    _solicitud.Txt_Comentario = _sifSolicitud.txt_comentario;
                    _solicitud.Txt_Estado = _sifSolicitud.txt_estado;
                    _solicitud.Txt_Motivo = _sifSolicitud.txt_motivo;
                    _solicitud.txt_Curso = _sifSolicitud.txt_curso;
                }

                _objConexionBase.Connection.Close();
                return _liSolicitudes;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /**
         * Retorna los grupos especificados en una solicitud de inclusion
         **/
        public LinkedList<Grupo_Por_Solicitud> ObtenerGruposInclusion(Solicitud pSolicitud)
        {
            try
            {
                _objConexionBase = new Inclutec_BDEntities();

                var _liGruposSolicitud = from _sifGruposSolicitud in _objConexionBase.SIFGrupo_Por_Solicitud
                                         where _sifGruposSolicitud.FK_Solicitud_idSolicitud == pSolicitud.Id_Solicitud
                                         select _sifGruposSolicitud;

                LinkedList<Grupo_Por_Solicitud> _liGrupos = new LinkedList<Grupo_Por_Solicitud>();

                foreach (SIFGrupo_Por_Solicitud _sifGrupoSolicitud in _liGruposSolicitud)
                {

                    //Obtiene el grupo por solicitud
                    Grupo_Por_Solicitud _gpsGrupo = new Grupo_Por_Solicitud();
                    _gpsGrupo.Id_Grupo_Por_Solicitud = _sifGrupoSolicitud.id_Grupo_Por_Solicitud;
                    _gpsGrupo.Num_Prioridad = _sifGrupoSolicitud.num_prioridad;

                    //Obtiene el grupo
                    SIFGrupo _sifGrupo = (from _sifGrupos in _objConexionBase.SIFGrupoes
                                          where _sifGrupos.id_Grupo == _sifGrupoSolicitud.FK_Grupo_idGrupo
                                          select _sifGrupos).First();

                    Grupo _gGrupo = new Grupo();
                    _gGrupo.Id_Curso = _sifGrupo.FK_Curso_idCurso;
                    _gGrupo.Id_Grupo = _sifGrupo.id_Grupo;
                    _gGrupo.Num_Cupos = _sifGrupo.num_cupos;
                    _gGrupo.Num_Cupos_Extra = _sifGrupo.num_cupos_extra;
                    _gGrupo.Num_Grupo = _sifGrupo.num_grupo;

                    //Define los horarios para los grupos
                    var _liHorarios = from _sitHorarios in _objConexionBase.SITHorarios
                                      where _sitHorarios.FK_Grupo_idGrupo == _gGrupo.Id_Grupo
                                      select _sitHorarios;

                    _gGrupo.Li_Horarios = new LinkedList<Horario>();

                    foreach (SITHorario _sitHorario in _liHorarios)
                    {
                        Horario _hHorario = new Horario();
                        _hHorario.Id_Horario = _sitHorario.id_Horario;
                        _hHorario.Txt_Dia = _sitHorario.txt_dia;
                        _hHorario.Txt_Hora_Final = _sitHorario.tim_hora_fin.ToString();
                        _hHorario.Txt_Hora_Inicio = _sitHorario.tim_hora_inicio.ToString();
                        _gGrupo.Li_Horarios.AddLast(_hHorario);
                    }

                    //Define el grupo de grupo por solicitud
                    _gpsGrupo.Id_Grupo = _gGrupo;

                    //Agrega grupo por solicitud a la lista
                    _liGrupos.AddLast(_gpsGrupo);
                }

                _objConexionBase.Connection.Close();
                return _liGrupos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /**
         * Guarda los datos del Estudiante en la base de datos
         **/
        public bool GuardarDatosEstudiantes(Estudiante pEstudiante, int pPlanEstudios)
        {
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            _objConexionBase = new Inclutec_BDEntities();
            try
            {
                if (_metEstudiante.EstudianteExiste(pEstudiante.Id_Carnet))
                {
                    SIFEstudiante _sifEstudiante = (from _sifEstudiantes in _objConexionBase.SIFEstudiantes
                                                    where _sifEstudiantes.id_Carnet == pEstudiante.Id_Carnet
                                                    select _sifEstudiantes).First();
                    _sifEstudiante.dir_email = pEstudiante.Dir_Email;
                    _sifEstudiante.num_celular = pEstudiante.Num_Celular;
                    _sifEstudiante.num_telefono = pEstudiante.Num_Telefono;
                }
                else
                {
                    SIFEstudiante _sifeEstudiante = new SIFEstudiante();
                    _sifeEstudiante.id_Carnet = pEstudiante.Id_Carnet;
                    _sifeEstudiante.nom_nombre = pEstudiante.Nom_Nombre;
                    _sifeEstudiante.txt_apellido_1 = pEstudiante.Txt_Apellido1;
                    _sifeEstudiante.txt_apellido_2 = pEstudiante.Txt_Apellido2;
                    _sifeEstudiante.num_telefono = pEstudiante.Num_Telefono;
                    _sifeEstudiante.num_celular = pEstudiante.Num_Celular;
                    _sifeEstudiante.dir_email = pEstudiante.Dir_Email;
                    _sifeEstudiante.FK_PlanEstudios_idPlanEstudios = pPlanEstudios;

                    _objConexionBase.AddToSIFEstudiantes(_sifeEstudiante);
                }

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
         * Guarda la solicitud creada por el _sifeEstudiante
         **/
        public Solicitud GuardarSolicitud(string pEstudiante, int pPeriodo,
            Solicitud pSolicitud)
        {
            try
            {
                SIFSolicitud _sifSolicitud = new SIFSolicitud();
                _sifSolicitud.txt_comentario = pSolicitud.Txt_Comentario;
                _sifSolicitud.txt_curso = pSolicitud.txt_Curso;
                _sifSolicitud.txt_estado = pSolicitud.Txt_Estado;
                _sifSolicitud.txt_motivo = pSolicitud.Txt_Motivo;
                _sifSolicitud.grupo_aceptado = 0;
                _sifSolicitud.fec_creacion = pSolicitud.Fec_Creacion;
                _sifSolicitud.FK_Estudiante_carnet = pEstudiante;
                _sifSolicitud.FK_Periodo_idPeriodo = pPeriodo;

                _objConexionBase = new Inclutec_BDEntities();
                _objConexionBase.AddToSIFSolicituds(_sifSolicitud);
                _objConexionBase.SaveChanges();
                _objConexionBase.Connection.Close();
                pSolicitud.Id_Solicitud = _sifSolicitud.id_Solicitud;
                return pSolicitud;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Guarda los grupos de una solicitud
        /// </summary>
        /// <param name="pSolicitud"></param>
        /// <param name="pGrupos">Debe ir ordenada en cuanto a prioridad, 
        /// entre mayor la prioridad, mas antes tiene que ir el grupo</param>
        /// <returns></returns>
        public bool GuardarGruposSolicitud(Solicitud pSolicitud, LinkedList<Grupo> pGrupos)
        {
            try
            {
                int _iPrioridad = 1;
                _objConexionBase = new Inclutec_BDEntities();
                foreach (Grupo _gGrupo in pGrupos)
                {
                    SIFGrupo_Por_Solicitud _sifGrupo = new SIFGrupo_Por_Solicitud();
                    _sifGrupo.num_prioridad = _iPrioridad;
                    _sifGrupo.FK_Grupo_idGrupo = _gGrupo.Id_Grupo;
                    _sifGrupo.FK_Solicitud_idSolicitud = pSolicitud.Id_Solicitud;
                    _objConexionBase.AddToSIFGrupo_Por_Solicitud(_sifGrupo);
                    _iPrioridad++;
                }

                _objConexionBase.SaveChanges();
                _objConexionBase.Connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Modifica los grupos especificados en una solicitud
        /// </summary>
        /// <param name="pSolicitud"></param>
        /// <param name="pEliminados">Contiene los ids de los grupos por solicitud eliminados</param>
        /// <returns></returns>
        public bool ModificiarSolicitud(Solicitud pSolicitud, LinkedList<int> pEliminados)
        {
            _objConexionBase = new Inclutec_BDEntities();

            //Obtiene los grupos por solicitud de la solicitud
            var _sifGrupos = from _sifGPS in _objConexionBase.SIFGrupo_Por_Solicitud
                             where _sifGPS.FK_Solicitud_idSolicitud == pSolicitud.Id_Solicitud
                             select _sifGPS;

            //Asigna las nuevas prioridades y elimina los grupos marcados a eliminar
            foreach (SIFGrupo_Por_Solicitud _sifGPS in _sifGrupos)
            {
                if (pEliminados.Contains(_sifGPS.id_Grupo_Por_Solicitud))
                {
                    _objConexionBase.DeleteObject(_sifGPS);
                }
                else
                {
                    foreach (Grupo_Por_Solicitud _gpsGrupo in pSolicitud.Li_Grupos)
                    {
                        if (_sifGPS.id_Grupo_Por_Solicitud == _gpsGrupo.Id_Grupo_Por_Solicitud)
                        {
                            _sifGPS.num_prioridad = _gpsGrupo.Num_Prioridad;
                            break;
                        }
                    }
                }
            }

            _objConexionBase.SaveChanges();
            _objConexionBase.Connection.Close();
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
