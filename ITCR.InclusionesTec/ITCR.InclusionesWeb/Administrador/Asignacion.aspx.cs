﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AjaxControlToolkit;

namespace ITCR.InclusionesWeb.Administrador
{
    public partial class Asignacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            lblPopupHeader.Text = "Error";
            lblPopupBody.Text = "El proceso no ha sido implementado.";
            Pop_Alerta.Show();
        }
        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.Url.PathAndQuery);
        }
    }
}