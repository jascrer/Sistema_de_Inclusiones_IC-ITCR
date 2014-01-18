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
            //Obtengo los datos del xml
            IMetodosAdministrador _metAdministrador = new MetodosAdministrador();
            LinkedList<Regla> _lisReglas = _metAdministrador.ObtenerInformacionReglas();
            var _lisReglasOrdenadas = _lisReglas.OrderBy(r => r.Posicion);

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

            for (int i = 0; i < _lisReglasOrdenadas.Count(); i++)
            {
                int index = i + 1;
                TableRow Row_Regla = new TableRow();
                TableCell Cel_Nombre = new TableCell(); //-- Nombre de regla
                Cel_Nombre.Text = _lisReglasOrdenadas.ElementAt(i).Nombre;
                Row_Regla.Cells.Add(Cel_Nombre);

                TableCell Cel_Activo = new TableCell();
                CheckBox chbActivar = new CheckBox(); //-- Activar o desactivar
                chbActivar.ID = index.ToString();
                if (_lisReglasOrdenadas.ElementAt(i).Estado == "habilitada")
                {
                    chbActivar.Checked = true;
                }
                Cel_Activo.Controls.Add(chbActivar);
                Row_Regla.Cells.Add(Cel_Activo);

                TableCell Cel_Acciones = new TableCell();
                //Agregar las acciones por fila de regla
                ImageButton btnSubir = new ImageButton(); //-- Incrementar prioridad
                btnSubir.ImageUrl = "../Images/table_move_row_up.png";
                btnSubir.AlternateText = "Subir";
                btnSubir.ToolTip = "Subir";
                btnSubir.CommandArgument = index.ToString();
                btnSubir.Click += new ImageClickEventHandler(btnSubir_Click);
                Cel_Acciones.Controls.Add(btnSubir);

                ImageButton btnBajar = new ImageButton(); //-- Decrementar prioridad
                btnBajar.ImageUrl = "../Images/table_move_row_down.png";
                btnBajar.AlternateText = "Bajar";
                btnBajar.ToolTip = "Bajar";
                btnBajar.CommandArgument = index.ToString();
                btnBajar.Click += new ImageClickEventHandler(btnBajar_Click);
                Cel_Acciones.Controls.Add(btnBajar);

                Row_Regla.Cells.Add(Cel_Acciones);
                tblReglas.Rows.Add(Row_Regla);
            }

        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            ImageButton boton = sender as ImageButton;
            TableCell celda = boton.Parent as TableCell;
            TableRow fila = celda.Parent as TableRow;
            int indexActual = tblReglas.Rows.GetRowIndex(fila);
            int indexNuevo = indexActual - 1;
            if (indexNuevo!=0)
            {
                tblReglas.Rows.Remove(fila);
                tblReglas.Rows.AddAt(indexNuevo, fila);
                IMetodosAdministrador _metAdministrador = new MetodosAdministrador();
            }
            else
            {
                //label.Text = "no se mueve";
            }
        }

        protected void btnBajar_Click(object sender, EventArgs e)
        {
            ImageButton boton = sender as ImageButton;
            TableCell celda = boton.Parent as TableCell;
            TableRow fila = celda.Parent as TableRow;
            int indexActual = tblReglas.Rows.GetRowIndex(fila);
            int indexNuevo = indexActual + 1;
            if (indexNuevo != tblReglas.Rows.Count)
            {
                tblReglas.Rows.Remove(fila);
                tblReglas.Rows.AddAt(indexNuevo, fila);
            }
            else
            {
                //label.Text = "no se mueve";
            }

            //int rowIndex = int.Parse(((ImageButton)sender).CommandArgument);
            //int newIndex = rowIndex + 1;
            //Label label = new Label();
            //if(newIndex!=tblReglas.Rows.Count)
            //{
            //    label.Text = rowIndex.ToString() + "->" + newIndex;
            //}
            //else
            //{
            //    label.Text = "no se mueve";
            //}
            //tblReglas.Rows[rowIndex].Cells[2].Controls.Add(label);
        }

        
    }
}