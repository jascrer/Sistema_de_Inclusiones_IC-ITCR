using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AjaxControlToolkit;

#region Librerias Inclutec
using ITCR.Ado.ClasesComunes;
using ITCR.MetodosAccesoDatos.Clases;
using ITCR.MetodosAccesoDatos.Interfaces;
#endregion

namespace ITCR.InclusionesWeb.Estudiante
{
    public partial class Formulario : System.Web.UI.Page
    {
        /// <summary>
        /// Define las acciones a la hora de cargar la pagina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //GET datos estudiante con un carnet
                string Txt_Carnet = (string)Session["NUsuario"];

                IMetodosEstudiante _metEstudiante = new MetodosEstudiante();

                #region Obtener Datos Estudiante
                //Revisamos si el estudiante existe en la bd local
                bool Bin_EstudianteExiste = _metEstudiante.EstudianteExiste(Txt_Carnet);
                //Obtenemos info del estudiante
                Ado.ClasesComunes.Estudiante _estudianteNuevo = new Ado.ClasesComunes.Estudiante();
                _estudianteNuevo = _metEstudiante.ObtenerDatosEstudiante(Txt_Carnet, Bin_EstudianteExiste);
                //Obtenemos plan de estudios del estudiante y lo asignamos
                Ado.ClasesComunes.PlanEstudios _planNuevo = new Ado.ClasesComunes.PlanEstudios();
                _planNuevo = _metEstudiante.ObtenerPlanEstudios(Txt_Carnet, Bin_EstudianteExiste);
                if (!Bin_EstudianteExiste)
                {
                    _estudianteNuevo.Id_Plan_Estudios = _planNuevo.Id_Plan_Estudios;
                }

                //Datos de backup
                string Txt_Sede = "CARTAGO";
                /*ojo*/
                //string Txt_CitaMatricula = _metEstudiante.ObtenerCitaMatricula(Txt_Carnet);
                #endregion

                #region Datos Asignados
                //Asigna datos estudiante a controles
                lblNombreCompleto.Text = _estudianteNuevo.Txt_Apellido1 + " " + _estudianteNuevo.Txt_Apellido2 + " " + _estudianteNuevo.Nom_Nombre;
                lblCarnet.Text = _estudianteNuevo.Id_Carnet;
                lblCarrera.Text = _planNuevo.Nom_Carrera;
                lblSede.Text = Txt_Sede;
                lblPlan.Text = _planNuevo.Id_Plan_Estudios.ToString();
                lblCitaMatricula.Text = Txt_CitaMatricula;
                txtTelefono.Text = _estudianteNuevo.Num_Telefono;
                txtCelular.Text = _estudianteNuevo.Num_Celular;
                txtCorreo.Text = _estudianteNuevo.Dir_Email;
                #endregion

                #region Cursos
                //Encuentra cursos y llena el autocomplete
                LinkedList<Curso> _cursos = new LinkedList<Curso>();
                _cursos = _metEstudiante.ObtenerCursosEstudiante(Txt_Carnet, null);

                foreach (var _cursoActual in _cursos)
                {
                    ListItem _item = new ListItem();
                    _item.Value = _cursoActual.Id_Curso.ToString();
                    _item.Text = _cursoActual.Txt_Curso;
                    ddlCursos.Items.Add(_item);
                }
                #endregion

                #region Grupos
                LinkedList<Grupo> _liGrupos = _metEstudiante.ObtenerGruposParaInclusion(Int32.Parse(ddlCursos.SelectedValue));

                if (_liGrupos.Count != 0)
                {
                    //-- Encabezado de la tabla
                    TableHeaderRow Row_Encabezado = new TableHeaderRow();
                    TableHeaderCell Cel_EncabezadoEstudiante = new TableHeaderCell();
                    Cel_EncabezadoEstudiante.Text = "Número";
                    Row_Encabezado.Cells.Add(Cel_EncabezadoEstudiante);
                    TableHeaderCell Cel_EncabezadoCurso = new TableHeaderCell();
                    Cel_EncabezadoCurso.Text = "Profesor";
                    Row_Encabezado.Cells.Add(Cel_EncabezadoCurso);
                    TableHeaderCell Cel_EncabezadoGrupo = new TableHeaderCell();
                    Cel_EncabezadoGrupo.Text = "Horario";
                    Row_Encabezado.Cells.Add(Cel_EncabezadoGrupo);
                    TableHeaderCell Cel_EncabezadoAcciones = new TableHeaderCell();
                    Cel_EncabezadoAcciones.Text = "Acciones";
                    Row_Encabezado.Cells.Add(Cel_EncabezadoAcciones);
                    tblGrupos.Rows.Add(Row_Encabezado);

                    foreach (var _grupo in _liGrupos)
                    {
                        TableRow Row_Excepcion = new TableRow();

                        TableCell Cel_Estudiante = new TableCell();
                        Cel_Estudiante.Text = _grupo.Num_Grupo.ToString();
                        Row_Excepcion.Cells.Add(Cel_Estudiante);

                        TableCell Cel_Curso = new TableCell();
                        Cel_Curso.Text = _metEstudiante.ObtenerProfesor(_grupo.Id_Grupo);
                        Row_Excepcion.Cells.Add(Cel_Curso);

                        TableCell Cel_Grupo = new TableCell();
                        Cel_Grupo.Text = CrearHorario(_grupo.Li_Horarios);
                        Row_Excepcion.Cells.Add(Cel_Grupo);

                        TableCell Cel_Acciones = new TableCell();
                        ImageButton btnEliminar = new ImageButton();
                        btnEliminar.ImageUrl = "../Images/table_delete_row.png";
                        btnEliminar.AlternateText = "Eliminar";
                        btnEliminar.Enabled = false;
                        btnEliminar.ToolTip = "Eliminar";
                        //btnEliminar.Click += new ImageClickEventHandler(btnEliminar_Click);
                        Cel_Acciones.Controls.Add(btnEliminar);
                        Row_Excepcion.Cells.Add(Cel_Acciones);

                        tblGrupos.Rows.Add(Row_Excepcion);
                    }
                }
                else
                {
                    TableRow Row_SinExcepciones = new TableRow();
                    TableCell Cel_SinExcepciones = new TableCell();
                    Cel_SinExcepciones.Text = "No se encuentran grupos para este curso";
                    Row_SinExcepciones.Cells.Add(Cel_SinExcepciones);
                    tblGrupos.Rows.Add(Row_SinExcepciones);
                }
                #endregion

                Session["Estudiante"] = _estudianteNuevo;
                Session["Plan"] = _planNuevo;
            }
        }

        private string CrearHorario(LinkedList<Horario> pHorarios)
        {
            string _sHorario = "";
            foreach (Horario _horario in pHorarios)
            {
                _sHorario += _horario.Txt_Dia + " " + 
                    _horario.Txt_Hora_Inicio + " - " + 
                    _horario.Txt_Hora_Final;
            } return _sHorario;
        }

        /// <summary>
        /// Define las acciones a ejecutar cuando se cambia el index del
        /// DropDownList Cursos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _curso = int.Parse(ddlCursos.SelectedValue);

            if (ddlCursos.SelectedValue != "0")
            {
                IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
                LinkedList<Grupo> _lisGrupos = _metEstudiante.ObtenerGruposParaInclusion(_curso);

                tblGrupos.Rows.Clear();//-- Encabezado de la tabla
                TableHeaderRow Row_Encabezado = new TableHeaderRow();
                TableHeaderCell Cel_EncabezadoEstudiante = new TableHeaderCell();
                Cel_EncabezadoEstudiante.Text = "Número";
                Row_Encabezado.Cells.Add(Cel_EncabezadoEstudiante);
                TableHeaderCell Cel_EncabezadoCurso = new TableHeaderCell();
                Cel_EncabezadoCurso.Text = "Profesor";
                Row_Encabezado.Cells.Add(Cel_EncabezadoCurso);
                TableHeaderCell Cel_EncabezadoGrupo = new TableHeaderCell();
                Cel_EncabezadoGrupo.Text = "Horario";
                Row_Encabezado.Cells.Add(Cel_EncabezadoGrupo);
                TableHeaderCell Cel_EncabezadoAcciones = new TableHeaderCell();
                Cel_EncabezadoAcciones.Text = "Acciones";
                Row_Encabezado.Cells.Add(Cel_EncabezadoAcciones);
                tblGrupos.Rows.Add(Row_Encabezado);

                foreach (var _grupo in _lisGrupos)
                {
                    TableRow Row_Excepcion = new TableRow();

                    TableCell Cel_Estudiante = new TableCell();
                    Cel_Estudiante.Text = _grupo.Num_Grupo.ToString();
                    Row_Excepcion.Cells.Add(Cel_Estudiante);

                    TableCell Cel_Curso = new TableCell();
                    Cel_Curso.Text = _metEstudiante.ObtenerProfesor(_grupo.Id_Grupo);
                    Row_Excepcion.Cells.Add(Cel_Curso);

                    TableCell Cel_Grupo = new TableCell();
                    Cel_Grupo.Text = CrearHorario(_grupo.Li_Horarios);
                    Row_Excepcion.Cells.Add(Cel_Grupo);

                    TableCell Cel_Acciones = new TableCell();
                    ImageButton btnEliminar = new ImageButton();
                    btnEliminar.ImageUrl = "../Images/table_delete_row.png";
                    btnEliminar.AlternateText = "Eliminar";
                    btnEliminar.Enabled = false;
                    btnEliminar.ToolTip = "Eliminar";
                    //btnEliminar.Click += new ImageClickEventHandler(btnEliminar_Click);
                    Cel_Acciones.Controls.Add(btnEliminar);
                    Row_Excepcion.Cells.Add(Cel_Acciones);

                    tblGrupos.Rows.Add(Row_Excepcion);
                }
                tblGrupos.DataBind();
            }
            else
            {
                //ddlGrupo.Items.Clear();
            }

        }

        /// <summary>
        /// Define las acciones del boton Enviar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Ado.ClasesComunes.Estudiante _estudianteDatos = (Ado.ClasesComunes.Estudiante)Session["Estudiante"];
            PlanEstudios _planEstudios = (PlanEstudios)Session["Plan"];

            IMetodosAdministrador _metAdmin = new MetodosAdministrador();
            Periodo _perUltimo = _metAdmin.UltimoPeriodo();

            Solicitud _solicitudNueva = new Solicitud();
            _solicitudNueva.Fec_Creacion = DateTime.Now;
            _solicitudNueva.Txt_Comentario = txtComentario.Text;
            _solicitudNueva.txt_Curso = ddlCursos.SelectedValue;
            _solicitudNueva.Txt_Estado = "PENDIENTE";
            _solicitudNueva.Txt_Motivo = "";

            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            _metEstudiante.GuardarDatosEstudiantes(_estudianteDatos, _planEstudios.Id_Plan_Estudios);

            if ((_perUltimo.Fec_Inicio <= _solicitudNueva.Fec_Creacion) &&
                (_perUltimo.Fec_Fin >= _solicitudNueva.Fec_Creacion))
            {
                _metEstudiante.GuardarSolicitud(_estudianteDatos.Id_Carnet, _perUltimo.Id_Periodo, _solicitudNueva);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Error al crear la solicitud",
                    "alert('Su solicitud no pudo ser procesada, ya que no fue realizada dentro del periodo de recepción');",true);
            }
        }

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.Url.PathAndQuery);
        }
            
    }
}