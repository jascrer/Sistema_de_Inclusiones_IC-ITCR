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
    public partial class Periodo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtAnio.Text = DateTime.Now.Year.ToString();
        }

        protected void btnDefinirPeriodo_Click(object sender, EventArgs e)
        {
            IMetodosAdministrador _metAdministrador = new MetodosAdministrador();
            if (_metAdministrador.UltimoPeriodo() == null)
            {
                //GET datos para creacion de periodo
                string txt_Modalidad = ddlModalidad.SelectedValue;//"S"
                int num_Periodo = int.Parse(ddlPeriodo.SelectedValue);//
                int num_Anio = int.Parse(txtAnio.Text);
                string txt_FechaInicio = txtFechaInicio.Text;
                string txt_FechaFin = txtFechaFinal.Text;

                Ado.ClasesComunes.Periodo _periodoNuevo = new Ado.ClasesComunes.Periodo();
                _periodoNuevo.Txt_Modalidad = txt_Modalidad;
                _periodoNuevo.Num_Periodo = num_Periodo;
                _periodoNuevo.Num_Anno = num_Anio;
                _periodoNuevo.Fec_Inicio = DateTime.Parse(txt_FechaInicio + " 00:00:00");
                _periodoNuevo.Fec_Fin = DateTime.Parse(txt_FechaFin + " 00:00:00");
                _periodoNuevo.Txt_Estado = "En Curso";

                //Guardar en BD
                _metAdministrador.DefinirPeriodoSolicitud(_periodoNuevo);
                lblPopupHeader.Text = "Periodo Definido";
                lblPopupBody.Text = "El periodo de recepción de solicitudes ha sido definido de manera exitosa dentro del sistema.";
                Pop_Alerta.Show();
            }
            else
            {
                // Ya hay un periodo definido y en curso
                lblPopupHeader.Text = "Error al definir el periodo";
                lblPopupBody.Text = "El periodo no fue creado, ya que existe un periodo de asignación en curso.";
                Pop_Alerta.Show();
            }
            

        }

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.Url.PathAndQuery);
        }
    }
}