using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITCR.InclusionesWeb.Administrador
{
    public partial class Consultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            string tipoConsulta = ddlConsulta.SelectedValue;
            TableCell celda = new TableCell();
            celda.Text = tipoConsulta;
            TableRow fila = new TableRow();
            fila.Cells.Add(celda);
            tblConsulta.Rows.Add(fila);
        }
    }
}