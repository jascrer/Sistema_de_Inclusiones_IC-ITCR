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
                    //-- Encabezado de la tabla

                    TableHeaderRow Row_Encabezado = new TableHeaderRow();
                    TableHeaderCell Cel_EncabezadoEstudiante = new TableHeaderCell();
                    Cel_EncabezadoEstudiante.Text = "Estudiante";
                    TableHeaderCell Cel_EncabezadoCurso = new TableHeaderCell();
                    Cel_EncabezadoCurso.Text = "Curso";
                    TableHeaderCell Cel_EncabezadoGrupo = new TableHeaderCell();
                    Cel_EncabezadoGrupo.Text = "Grupo";
                    TableHeaderCell Cel_EncabezadoAcciones = new TableHeaderCell();
                    Cel_EncabezadoAcciones.Text = "Acciones";
                    tblExcepciones.Rows.Add(Row_Encabezado);

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
                }
                else
                {
                    TableRow Row_SinExcepciones = new TableRow();
                    TableCell Cel_SinExcepciones = new TableCell();
                    Cel_SinExcepciones.Text = "No se encuentran excepciones para este periodo";
                    Row_SinExcepciones.Cells.Add(Cel_SinExcepciones);
                    tblExcepciones.Rows.Add(Row_SinExcepciones);
                }




                //Encuentra cursos y llena el autocomplete
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
            }
        }

        protected void btnAgregarExcepcion_Click(object sender, EventArgs e)
        {
            lblPopupHeader.Text = "Excepcion Agregada";
            lblPopupBody.Text = "La excepcion ha sido agregada correctamente al sistema.";
            Pop_Alerta.Show();
            //Page.Response.Redirect(Page.Request.Url.PathAndQuery);
        }

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.Url.PathAndQuery);
        }
    }
}