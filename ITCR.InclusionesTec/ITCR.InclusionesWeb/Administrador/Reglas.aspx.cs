using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITCR.InclusionesWeb.Administrador
{
    public partial class Reglas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkedList<string> Lis_NombreReglas = new LinkedList<string>();

            //Obtengo los datos del xml e itero para crear lista
            Lis_NombreReglas.AddLast("Excepciones del sistema");
            Lis_NombreReglas.AddLast("Próximo a graduación");
            Lis_NombreReglas.AddLast("Cursos insuficientes");
            Lis_NombreReglas.AddLast("Por cita de matrícula");

            //Lleno la tabla de reglas
            TableHeaderRow Row_Encabezado = new TableHeaderRow();//-- Encabezado de tabla
            TableHeaderCell Cel_Encabezado = new TableHeaderCell();
            Cel_Encabezado.Text = "Regla de negocio";
            Row_Encabezado.Cells.Add(Cel_Encabezado);
            Cel_Encabezado.Text = "Acciones";
            Row_Encabezado.Cells.Add(Cel_Encabezado);
            tblReglas.Rows.Add(Row_Encabezado);

            foreach (var regla in Lis_NombreReglas){//-- Filas por regla
                TableRow Row_Regla = new TableRow();
                TableCell Cel_Nombre = new TableCell();
                Cel_Nombre.Text = regla;
                Row_Regla.Cells.Add(Cel_Nombre);
                TableCell Cel_Acciones = new TableCell();
                //Agregar las acciones por fila de regla
                CheckBox chbActivar = new CheckBox(); //-- Activar o desactivar
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