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
                IMetodosEstudiante _metEstudiante = new MetodosEstudiante();

                //Encuentra cursos y llena el autocomplete
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
    }
}