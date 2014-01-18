using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITCR.InclusionesWeb
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!((string)Session["Nombre"]).Equals(""))
                {
                    Bienvenido.Text = "Bienvenido/a, ";
                    HeadLoginName.Text = (string)Session["Nombre"];
                    Cerrar.Text = "Cerrar Sesión";
                }
            }
            catch
            {

            }

        }
    }
}
