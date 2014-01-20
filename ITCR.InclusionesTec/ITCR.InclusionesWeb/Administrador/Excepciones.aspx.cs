using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Librerias Inclutec
using ITCR.Ado.ClasesComunes;
using ITCR.MetodosAccesoDatos.Clases;
using ITCR.MetodosAccesoDatos.Interfaces;
#endregion

using AjaxControlToolkit;

namespace ITCR.InclusionesWeb.Administrador
{
    public partial class Excepciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //Llenado de tabla de excepciones del periodo actual
                IMetodosAdministrador _metAdministrador = new MetodosAdministrador();
                Ado.ClasesComunes.Periodo _periodoActual = _metAdministrador.UltimoPeriodo();
                LinkedList<Excepcion> _lisExcepciones = _metAdministrador.ObtenerListaExcepciones(_periodoActual.Id_Periodo);

                if(_lisExcepciones.Count != 0)
                {
                    #region Encabezado de la tabla

                    TableHeaderRow Row_Encabezado = new TableHeaderRow();
                    TableHeaderCell Cel_EncabezadoEstudiante = new TableHeaderCell();
                    Cel_EncabezadoEstudiante.Text = "Estudiante";
                    Row_Encabezado.Cells.Add(Cel_EncabezadoEstudiante);
                    TableHeaderCell Cel_EncabezadoCurso = new TableHeaderCell();
                    Cel_EncabezadoCurso.Text = "Curso";
                    Row_Encabezado.Cells.Add(Cel_EncabezadoCurso);
                    TableHeaderCell Cel_EncabezadoGrupo = new TableHeaderCell();
                    Cel_EncabezadoGrupo.Text = "Grupo";
                    Row_Encabezado.Cells.Add(Cel_EncabezadoGrupo);
                    TableHeaderCell Cel_EncabezadoAcciones = new TableHeaderCell();
                    Cel_EncabezadoAcciones.Text = "Acciones";
                    Row_Encabezado.Cells.Add(Cel_EncabezadoAcciones);
                    tblExcepciones.Rows.Add(Row_Encabezado);

                    #endregion

                    #region Llenado de tabla
                    //-- Agrego filas a la tabla
                    foreach(var _excepcion in _lisExcepciones)
                    {
                        TableRow Row_Excepcion = new TableRow();

                        TableCell Cel_Estudiante = new TableCell();
                        Cel_Estudiante.Text = _excepcion.Id_Estudiante;
                        Row_Excepcion.Cells.Add(Cel_Estudiante);

                        TableCell Cel_Curso = new TableCell();
                        Cel_Curso.Text = _excepcion.Id_Curso.ToString();
                        Row_Excepcion.Cells.Add(Cel_Curso);

                        TableCell Cel_Grupo = new TableCell();
                        Cel_Grupo.Text = _excepcion.Id_Grupo.ToString();
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

                        tblExcepciones.Rows.Add(Row_Excepcion);
                    }
                    #endregion
                }
                else
                {
                    TableRow Row_SinExcepciones = new TableRow();
                    TableCell Cel_SinExcepciones = new TableCell();
                    Cel_SinExcepciones.Text = "No se encuentran excepciones para este periodo";
                    Row_SinExcepciones.Cells.Add(Cel_SinExcepciones);
                    tblExcepciones.Rows.Add(Row_SinExcepciones);
                }

                #region Encuentra cursos y llena el autocomplete
                IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
                LinkedList<Curso> _cursos = new LinkedList<Curso>();
                _cursos = _metEstudiante.ObtenerCursosEstudiante("", null);

                foreach (var _cursoActual in _cursos)
                {
                    ListItem _item = new ListItem();
                    _item.Value = _cursoActual.Id_Curso.ToString();
                    _item.Text = _cursoActual.Txt_Curso;
                    ddlCurso.Items.Add(_item);
                }
                #endregion
            }
        }

        protected void ddlCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem _curso = ddlCurso.SelectedItem;
            
            if (_curso.Value != "0")
            {
                IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
                LinkedList<Grupo> _lisGrupos = _metEstudiante.ObtenerGruposParaInclusion(int.Parse(_curso.Value));

                ddlGrupo.Items.Clear();
                ddlGrupo.DataSource = _lisGrupos;
                ddlGrupo.DataValueField = "Id_Grupo";
                ddlGrupo.DataTextField = "Num_Grupo";
                ddlGrupo.DataBind();
            }
            else
            {
                ddlGrupo.Items.Clear();                
            }

        }

        protected void btnAgregarExcepcion_Click(object sender, EventArgs e)
        {
            IMetodosAdministrador _metAdministrador = new MetodosAdministrador();
            string _carnet = txtCarnet.Text;
            int _idCurso = int.Parse(ddlCurso.SelectedValue);
            int _idGrupo = int.Parse(ddlGrupo.SelectedValue);

            Ado.ClasesComunes.Periodo _periodoActual = new Ado.ClasesComunes.Periodo();
            _periodoActual = _metAdministrador.UltimoPeriodo();

            if(_periodoActual != null)
            {
                bool _resultado = _metAdministrador.CrearExcepcion(_periodoActual.Id_Periodo, _idCurso, _idGrupo, _carnet);

                if(_resultado)
                {
                    lblPopupHeader.Text = "Excepcion Agregada";
                    lblPopupBody.Text = "La excepcion ha sido agregada correctamente al sistema.";
                    Pop_Alerta.Show();
                }
                else
                {
                    lblPopupHeader.Text = "Error al agregar excepcion";
                    lblPopupBody.Text = "La excepcion no pudo ser agregada al sistema.";
                    Pop_Alerta.Show();
                }
            }
            else
            {
                lblPopupHeader.Text = "Error al agregar excepcion";
                lblPopupBody.Text = "No existe un periodo de recepcion definido aún.";
                Pop_Alerta.Show();
            }
        }

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.Url.PathAndQuery);
        }

    }
}