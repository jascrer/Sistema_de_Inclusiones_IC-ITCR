using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITCR.InclusionesWeb.Administrador
{
    public partial class Periodo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDefinirPeriodo_Click(object sender, EventArgs e)
        {
            //GET datos para creacion de periodo
            string txt_Modalidad = ddlModalidad.SelectedValue;//"S"
            int num_Periodo = int.Parse(ddlPeriodo.SelectedValue);//
            int num_Anio = int.Parse(txtAnio.Text);
            string txt_FechaInicio = txtFechaInicio.Text;
            string txt_FechaFin = txtFechaFinal.Text;
        }
    }
}