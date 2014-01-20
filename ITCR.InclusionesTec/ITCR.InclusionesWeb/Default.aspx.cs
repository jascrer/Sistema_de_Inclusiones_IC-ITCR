using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ITCR.MetodosAccesoDatos.Clases;
using ITCR.MetodosAccesoDatos.Interfaces;

namespace ITCR.InclusionesWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["TipoUsuario"] = "";
            Session["NUsuario"] = "";
            Session["Nombre"] = "";
        }

        protected void btnInicioSesion_Click(object sender, EventArgs e)
        {
            Session["TipoUsuario"] = ddlTipoUsuario.SelectedValue;
            Session["NUsuario"] = txtNombreUsuario.Text;

            IMetodosLogin _metLogin = new MetodosLogin();
            if (_metLogin.VerificarUsuario(txtNombreUsuario.Text, txtContrasena.Text, Int32.Parse(ddlTipoUsuario.SelectedValue)))
            {
                switch (Int32.Parse(ddlTipoUsuario.SelectedValue))
                {
                    case 0:
                        IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
                        Ado.ClasesComunes.Estudiante _estAlumno = _metEstudiante.ObtenerDatosEstudiante(txtNombreUsuario.Text,
                                                                        _metEstudiante.EstudianteExiste(txtNombreUsuario.Text));
                        Session["Nombre"] = _estAlumno.Nom_Nombre + " " + _estAlumno.Txt_Apellido1 + " " + _estAlumno.Txt_Apellido2;
                        Response.Redirect("~/Estudiante/Default.aspx");
                        break;
                    case 1:
                        Session["Nombre"] = txtNombreUsuario.Text;
                        Response.Redirect("~/Administrador/Default.aspx");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Datos de sesión incorrectos",
                    "alert('Los datos de inicio de sesión son incorrectos');", true);
            }
        }
    }
}
