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

namespace ITCR.InclusionesWeb.Administrador
{
    public partial class Reglas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkedList<string> Lis_NombreReglas = new LinkedList<string>();

            //Obtengo los datos del xml
            IMetodosAdministrador _metAdministrador = new MetodosAdministrador();
            LinkedList<Regla> Lis_Reglas = _metAdministrador.ObtenerInformacionReglas();
            var Lis_ReglasOrdenadas = Lis_Reglas.OrderBy(r => r.Posicion);
            LinkedList<string> lista = new LinkedList<string>();
            lista.AddLast("a");
            lista.AddLast("b");
            lista.AddLast("c");

            //Lleno la tabla de reglas
            TableHeaderRow Row_Encabezado = new TableHeaderRow();//-- Encabezado de tabla
            TableHeaderCell Cel_Encabezado1 = new TableHeaderCell();
            Cel_Encabezado1.Text = "Regla de negocio";
            Row_Encabezado.Cells.Add(Cel_Encabezado1);
            TableHeaderCell Cel_Encabezado2 = new TableHeaderCell();
            Cel_Encabezado2.Text = "Activa";
            Row_Encabezado.Cells.Add(Cel_Encabezado2);
            TableHeaderCell Cel_Encabezado3 = new TableHeaderCell();
            Cel_Encabezado3.Text = "Acciones";
            Row_Encabezado.Cells.Add(Cel_Encabezado3);
            tblReglas.Rows.Add(Row_Encabezado);

            foreach (var regla in lista)
            {//-- Filas por regla
                TableRow Row_Regla = new TableRow();
                TableCell Cel_Nombre = new TableCell(); //-- Nombre de regla
                Cel_Nombre.Text = regla;
                Row_Regla.Cells.Add(Cel_Nombre);

                TableCell Cel_Activo = new TableCell();
                CheckBox chbActivar = new CheckBox(); //-- Activar o desactivar
                Cel_Activo.Controls.Add(chbActivar);
                Row_Regla.Cells.Add(Cel_Activo);

                TableCell Cel_Acciones = new TableCell();
                //Agregar las acciones por fila de regla
                ImageButton btnSubir = new ImageButton(); //-- Incrementar prioridad
                btnSubir.ImageUrl = "../Images/table_move_row_up.png";
                btnSubir.AlternateText = "Subir";
                btnSubir.ToolTip = "Subir";
                Cel_Acciones.Controls.Add(btnSubir);

                ImageButton btnBajar = new ImageButton(); //-- Decrementar prioridad
                btnBajar.ImageUrl = "../Images/table_move_row_down.png";
                btnBajar.AlternateText = "Bajar";
                btnBajar.ToolTip = "Bajar";
                Cel_Acciones.Controls.Add(btnBajar);

                Row_Regla.Cells.Add(Cel_Acciones);
                tblReglas.Rows.Add(Row_Regla);
            }

        }
    }
}