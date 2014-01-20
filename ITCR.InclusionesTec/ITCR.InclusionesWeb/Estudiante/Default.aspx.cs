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

namespace ITCR.InclusionesWeb.Estudiante
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
                IMetodosAdministrador _metAdministrador = new MetodosAdministrador();
                Ado.ClasesComunes.Periodo _periodoActual = _metAdministrador.UltimoPeriodo();
                string _carnet = (string)Session["NUsuario"];

                if(_periodoActual != null)
                {

                    #region Pendientes

                    LinkedList<Solicitud> _lisPendientes = _metEstudiante.ObtenerSolicitudesPendientes(_carnet, _periodoActual.Id_Periodo);
                    if (_lisPendientes.Count != 0)
                    {
                        #region Encabezado

                        TableHeaderRow Row_Encabezado = new TableHeaderRow();
                        TableHeaderCell Cel_EncabezadoID = new TableHeaderCell();
                        Cel_EncabezadoID.Text = "Solicitud";
                        Row_Encabezado.Cells.Add(Cel_EncabezadoID);
                        TableHeaderCell Cel_EncabezadoNomCurso = new TableHeaderCell();
                        Cel_EncabezadoNomCurso.Text = "Nombre de Curso";
                        Row_Encabezado.Cells.Add(Cel_EncabezadoNomCurso);
                        TableHeaderCell Cel_EncabezadoFecha = new TableHeaderCell();
                        Cel_EncabezadoFecha.Text = "Recepción";
                        Row_Encabezado.Cells.Add(Cel_EncabezadoFecha);
                        TableHeaderCell Cel_EncabezadoAcciones = new TableHeaderCell();
                        Cel_EncabezadoAcciones.Text = "Acciones";
                        Row_Encabezado.Cells.Add(Cel_EncabezadoAcciones);
                        tblPendientes.Rows.Add(Row_Encabezado);

                        #endregion

                        #region Llenado de tabla

                        foreach (var _solicitud in _lisPendientes)
                        {
                            TableRow Row_Pendientes = new TableRow();

                            TableCell Cel_ID = new TableCell();
                            Cel_ID.Text = _solicitud.Id_Solicitud.ToString();
                            Row_Pendientes.Cells.Add(Cel_ID);

                            TableCell Cel_Curso = new TableCell();
                            Cel_Curso.Text = _solicitud.txt_Curso;
                            Row_Pendientes.Cells.Add(Cel_Curso);

                            TableCell Cel_Fecha = new TableCell();
                            Cel_Fecha.Text = _solicitud.Fec_Creacion.Date.ToString();
                            Row_Pendientes.Cells.Add(Cel_Fecha);

                            TableCell Cel_Acciones = new TableCell();
                            ImageButton btnEliminar = new ImageButton();
                            btnEliminar.ImageUrl = "../Images/table_cancel_row.png";
                            btnEliminar.AlternateText = "Anular";
                            btnEliminar.Enabled = false;
                            btnEliminar.ToolTip = "Anular";
                            //btnEliminar.Click += new ImageClickEventHandler(btnEliminar_Click);
                            Cel_Acciones.Controls.Add(btnEliminar);
                            Row_Pendientes.Cells.Add(Cel_Acciones);

                            tblPendientes.Rows.Add(Row_Pendientes);
                        }

                        #endregion
                    }
                    else
                    {
                        TableRow Row_SinPendientes = new TableRow();
                        TableCell Cel_SinPendientes = new TableCell();
                        Cel_SinPendientes.Text = "No se encuentran solicitudes pendientes para este periodo";
                        Row_SinPendientes.Cells.Add(Cel_SinPendientes);
                        tblPendientes.Rows.Add(Row_SinPendientes);
                    }

                    #endregion

                    #region Anuladas

                    LinkedList<Solicitud> _lisAnuladas = _metEstudiante.ObtenerSolicitudesAnuladas(_carnet, _periodoActual.Id_Periodo);
                    if (_lisAnuladas.Count != 0)
                    {
                        #region Encabezado

                        TableHeaderRow Row_Encabezado = new TableHeaderRow();
                        TableHeaderCell Cel_EncabezadoID = new TableHeaderCell();
                        Cel_EncabezadoID.Text = "Solicitud";
                        Row_Encabezado.Cells.Add(Cel_EncabezadoID);
                        TableHeaderCell Cel_EncabezadoNomCurso = new TableHeaderCell();
                        Cel_EncabezadoNomCurso.Text = "Nombre de Curso";
                        Row_Encabezado.Cells.Add(Cel_EncabezadoNomCurso);
                        TableHeaderCell Cel_EncabezadoFecha = new TableHeaderCell();
                        Cel_EncabezadoFecha.Text = "Recepción";
                        Row_Encabezado.Cells.Add(Cel_EncabezadoFecha);

                        #endregion

                        #region Llenado de tabla

                        foreach (var _solicitud in _lisAnuladas)
                        {
                            TableRow Row_Anuladas = new TableRow();

                            TableCell Cel_ID = new TableCell();
                            Cel_ID.Text = _solicitud.Id_Solicitud.ToString();
                            Row_Anuladas.Cells.Add(Cel_ID);

                            TableCell Cel_Curso = new TableCell();
                            Cel_Curso.Text = _solicitud.txt_Curso;
                            Row_Anuladas.Cells.Add(Cel_Curso);

                            TableCell Cel_Fecha = new TableCell();
                            Cel_Fecha.Text = _solicitud.Fec_Creacion.Date.ToString();
                            Row_Anuladas.Cells.Add(Cel_Fecha);

                            tblAnuladas.Rows.Add(Row_Anuladas);
                        }

                        #endregion
                    }
                    else
                    {
                        TableRow Row_SinAnuladas = new TableRow();
                        TableCell Cel_SinAnuladas = new TableCell();
                        Cel_SinAnuladas.Text = "No se encuentran solicitudes anuladas para este periodo";
                        Row_SinAnuladas.Cells.Add(Cel_SinAnuladas);
                        tblAnuladas.Rows.Add(Row_SinAnuladas);
                    }

                    #endregion

                    #region Aprobadas

                    LinkedList<Solicitud> _lisAprobadas = _metEstudiante.ObtenerSolicitudesAprobadas(_carnet, _periodoActual.Id_Periodo);
                    if (_lisAprobadas.Count != 0)
                    {
                        #region Encabezado

                        TableHeaderRow Row_Encabezado = new TableHeaderRow();
                        TableHeaderCell Cel_EncabezadoID = new TableHeaderCell();
                        Cel_EncabezadoID.Text = "Solicitud";
                        Row_Encabezado.Cells.Add(Cel_EncabezadoID);
                        TableHeaderCell Cel_EncabezadoNomCurso = new TableHeaderCell();
                        Cel_EncabezadoNomCurso.Text = "Nombre de Curso";
                        Row_Encabezado.Cells.Add(Cel_EncabezadoNomCurso);
                        TableHeaderCell Cel_EncabezadoGrupo = new TableHeaderCell();
                        Cel_EncabezadoGrupo.Text = "Grupo Aceptado";
                        Row_Encabezado.Cells.Add(Cel_EncabezadoGrupo);
                        tblPendientes.Rows.Add(Row_Encabezado);

                        #endregion

                        #region Llenado de tabla

                        foreach (var _solicitud in _lisAprobadas)
                        {
                            TableRow Row_Aprobadas = new TableRow();

                            TableCell Cel_ID = new TableCell();
                            Cel_ID.Text = _solicitud.Id_Solicitud.ToString();
                            Row_Aprobadas.Cells.Add(Cel_ID);

                            TableCell Cel_Curso = new TableCell();
                            Cel_Curso.Text = _solicitud.txt_Curso;
                            Row_Aprobadas.Cells.Add(Cel_Curso);

                            TableCell Cel_Grupo = new TableCell();
                            LinkedList<Curso> _cursos = _metEstudiante.ObtenerCursosEstudiante(_carnet, null);
                            LinkedList<Grupo> _grupos = new LinkedList<Grupo>();
                            int _idCurso;
                            foreach (var _curso in _cursos)
                            {
                                if (_curso.Txt_Curso.Equals(_solicitud.txt_Curso))
                                {
                                    _idCurso = _curso.Id_Curso;
                                    _grupos = _metEstudiante.ObtenerGruposParaInclusion(_idCurso);
                                }
                            }
                            //LinkedList<Grupo> _grupos = _metEstudiante.ObtenerGruposParaInclusion(_idCurso);
                            foreach (var _grupo in _grupos)
                            {
                                if (_grupo.Id_Grupo.Equals(_solicitud.Id_GrupoAceptado))
                                {
                                    Cel_Grupo.Text = _grupo.Num_Grupo.ToString();
                                }
                            }
                            Row_Aprobadas.Cells.Add(Cel_Grupo);

                            tblPendientes.Rows.Add(Row_Aprobadas);
                        }

                        #endregion
                    }
                    else
                    {
                        TableRow Row_SinAprobadas = new TableRow();
                        TableCell Cel_SinAprobadas = new TableCell();
                        Cel_SinAprobadas.Text = "No se encuentran solicitudes aprobadas para este periodo";
                        Row_SinAprobadas.Cells.Add(Cel_SinAprobadas);
                        tblAprobadas.Rows.Add(Row_SinAprobadas);
                    }

                    #endregion

                    #region Reprobadas

                    LinkedList<Solicitud> _lisReprobadas = _metEstudiante.ObtenerSolicitudesReprobadas(_carnet, _periodoActual.Id_Periodo);
                    if (_lisReprobadas.Count != 0)
                    {
                        #region Encabezado

                        TableHeaderRow Row_Encabezado = new TableHeaderRow();
                        TableHeaderCell Cel_EncabezadoID = new TableHeaderCell();
                        Cel_EncabezadoID.Text = "Solicitud";
                        Row_Encabezado.Cells.Add(Cel_EncabezadoID);
                        TableHeaderCell Cel_EncabezadoNomCurso = new TableHeaderCell();
                        Cel_EncabezadoNomCurso.Text = "Nombre de Curso";
                        Row_Encabezado.Cells.Add(Cel_EncabezadoNomCurso);
                        TableHeaderCell Cel_EncabezadoMotivo = new TableHeaderCell();
                        Cel_EncabezadoMotivo.Text = "Motivo";
                        Row_Encabezado.Cells.Add(Cel_EncabezadoMotivo);
                        tblReprobadas.Rows.Add(Row_Encabezado);

                        #endregion

                        #region Llenado de tabla

                        foreach (var _solicitud in _lisReprobadas)
                        {
                            TableRow Row_Reprobadas = new TableRow();

                            TableCell Cel_ID = new TableCell();
                            Cel_ID.Text = _solicitud.Id_Solicitud.ToString();
                            Row_Reprobadas.Cells.Add(Cel_ID);

                            TableCell Cel_Curso = new TableCell();
                            Cel_Curso.Text = _solicitud.txt_Curso;
                            Row_Reprobadas.Cells.Add(Cel_Curso);

                            TableCell Cel_Motivo = new TableCell();
                            Cel_Motivo.Text = _solicitud.Txt_Motivo;
                            Row_Reprobadas.Cells.Add(Cel_Motivo);

                            tblReprobadas.Rows.Add(Row_Reprobadas);
                        }

                        #endregion
                    }
                    else
                    {
                        TableRow Row_SinReprobadas = new TableRow();
                        TableCell Cel_SinReprobadas = new TableCell();
                        Cel_SinReprobadas.Text = "No se encuentran solicitudes reprobadas para este periodo";
                        Row_SinReprobadas.Cells.Add(Cel_SinReprobadas);
                        tblReprobadas.Rows.Add(Row_SinReprobadas);
                    }

                    #endregion
                }
                else
                {
                    lblPopupHeader.Text = "Alerta del sistema";
                    lblPopupBody.Text = "No existe un periodo de recepcion de solicitudes definido aún.";
                    Pop_Alerta.Show();
                }

            }
        }

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.Url.PathAndQuery);
        }
    }
}