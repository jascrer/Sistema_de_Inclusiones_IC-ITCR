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
            Session["LISTA_REGLAS"] = _lisReglas;
            if(_lisReglas != null)
            {
                var _lisReglasOrdenadas = _lisReglas.OrderBy(r => r.Posicion);//-- Ordeno la lista por prioridad

                //-- Encabezado de la tabla
                TableHeaderRow Row_Encabezado = new TableHeaderRow();
                TableHeaderCell Cel_EncabezadoNombre = new TableHeaderCell();
                Cel_EncabezadoNombre.Text = "Nombre de Regla";
                TableHeaderCell Cel_EncabezadoEstado = new TableHeaderCell();
                Cel_EncabezadoEstado.Text = "Estado";
                TableHeaderCell Cel_EncabezadoAcciones = new TableHeaderCell();
                Cel_EncabezadoAcciones.Text = "Acciones";
                tblReglas.Rows.Add(Row_Encabezado);

                //-- Agrego las filas a la tabla

                foreach(var _regla in _lisReglasOrdenadas)
                {
                    TableRow Row_Regla = new TableRow();

                    TableCell Cel_Nombre = new TableCell(); //-- Nombre de regla
                    Cel_Nombre.Text = _regla.Nombre;
                    Row_Regla.Cells.Add(Cel_Nombre);

                    TableCell Cel_Activo = new TableCell();
                    CheckBox chbActivar = new CheckBox(); //-- Activar o desactivar
                    if (_regla.Estado == "habilitada")
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
                    btnSubir.Click += new ImageClickEventHandler(btnSubir_Click);
                    Cel_Acciones.Controls.Add(btnSubir);

                    ImageButton btnBajar = new ImageButton(); //-- Decrementar prioridad
                    btnBajar.ImageUrl = "../Images/table_move_row_down.png";
                    btnBajar.AlternateText = "Bajar";
                    btnBajar.ToolTip = "Bajar";
                    btnBajar.Click += new ImageClickEventHandler(btnBajar_Click);
                    Cel_Acciones.Controls.Add(btnBajar);

                    Row_Regla.Cells.Add(Cel_Acciones);
                    tblReglas.Rows.Add(Row_Regla);
                }
            }
            else
            {
                TableRow Row_SinReglas = new TableRow();
                TableCell Cel_SinReglas = new TableCell();
                Cel_SinReglas.Text = "Se ha producido un error y la tabla no ha podido ser llenada";
                Row_SinReglas.Cells.Add(Cel_SinReglas);
                tblReglas.Rows.Add(Row_SinReglas);
            }
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            ImageButton boton = sender as ImageButton;
            TableCell celda = boton.Parent as TableCell;
            TableRow fila = celda.Parent as TableRow;
            string nombreRegla = fila.Cells[0].Text;
            int indexActual = tblReglas.Rows.GetRowIndex(fila);
            int indexNuevo = indexActual - 1;
            if (indexNuevo != 0)
            {
                IMetodosAdministrador _metAdministrador = new MetodosAdministrador();
                LinkedList<Regla> _lisReglas = (LinkedList<Regla>)Session["LISTA_REGLAS"];
                Regla _reglaSube = new Regla();
                Regla _reglaBaja = new Regla();

                foreach(Regla _regla in _lisReglas)//-- Obtengo las reglas por modificar
                {
                    if(_regla.Posicion.Equals(indexActual))
                    {
                        _reglaSube = _regla;
                    }
                    if(_regla.Posicion.Equals(indexNuevo))
                    {
                        _reglaBaja = _regla;
                    }
                }

                _lisReglas.Remove(_reglaSube);//-- Borro reglas de lista
                _lisReglas.Remove(_reglaBaja);

                _reglaSube.Posicion = indexNuevo;//-- Cambio las posiciones
                _reglaBaja.Posicion = indexActual;

                _lisReglas.AddLast(_reglaSube);//-- Agrego a la lista
                _lisReglas.AddLast(_reglaBaja);

                bool _resultado = _metAdministrador.ModificarOrdenReglas(_lisReglas);

                if(_resultado)
                {
                    Page.Response.Redirect(Page.Request.Url.PathAndQuery);
                }
                else
                {
                    lblPopupHeader.Text = "Error";
                    lblPopupBody.Text = "La prioridad de la regla no fue modificada.";
                    Pop_Alerta.Show();
                }
                
            }
            else
            {
                lblPopupHeader.Text = "Error";
                lblPopupBody.Text = "La regla ya tiene la prioridad máxima.";
                Pop_Alerta.Show();
            }
        }

        protected void btnBajar_Click(object sender, EventArgs e)
        {
            ImageButton boton = sender as ImageButton;
            TableCell celda = boton.Parent as TableCell;
            TableRow fila = celda.Parent as TableRow;
            string nombreRegla = fila.Cells[0].Text;
            int indexActual = tblReglas.Rows.GetRowIndex(fila);
            int indexNuevo = indexActual + 1;
            if (indexNuevo != tblReglas.Rows.Count)
            {
                IMetodosAdministrador _metAdministrador = new MetodosAdministrador();
                LinkedList<Regla> _lisReglas = (LinkedList<Regla>)Session["LISTA_REGLAS"];
                Regla _reglaBaja = new Regla();
                Regla _reglaSube = new Regla();

                foreach (Regla _regla in _lisReglas)//-- Obtengo las reglas por modificar
                {
                    if (_regla.Posicion.Equals(indexActual))//-- Aca el nombre sube o baja no tiene sentido
                    {
                        _reglaBaja = _regla;
                    }
                    if (_regla.Posicion.Equals(indexNuevo))
                    {
                        _reglaSube = _regla;
                    }
                }

                _lisReglas.Remove(_reglaSube);//-- Borro reglas de lista
                _lisReglas.Remove(_reglaBaja);

                _reglaSube.Posicion = indexActual;//-- Cambio las posiciones
                _reglaBaja.Posicion = indexNuevo;

                _lisReglas.AddLast(_reglaSube);//-- Agrego a la lista
                _lisReglas.AddLast(_reglaBaja);

                bool _resultado = _metAdministrador.ModificarOrdenReglas(_lisReglas);

                if (_resultado)
                {
                    Page.Response.Redirect(Page.Request.Url.PathAndQuery);
                }
                else
                {
                    lblPopupHeader.Text = "Error";
                    lblPopupBody.Text = "La prioridad de la regla no fue modificada.";
                    Pop_Alerta.Show();
                }

            }
            else
            {
                lblPopupHeader.Text = "Error";
                lblPopupBody.Text = "La regla ya tiene la prioridad mínima.";
                Pop_Alerta.Show();
            }
        }

        protected void btnAgregarRegla_Click(object sender, EventArgs e)
        {
            //Intento agregar regla al sistema
            IMetodosAdministrador _metAdministrador = new MetodosAdministrador();
            Regla _reglaNueva = new Regla();
            _reglaNueva.Posicion = tblReglas.Rows.Count;
            _reglaNueva.Nombre = txtNombreRegla.Text;
            _reglaNueva.StoredProcedure = txtNombreProcedimiento.Text;
            _reglaNueva.Estado = "habilitada";
            bool _resultado = _metAdministrador.AgregarRegla(_reglaNueva);
            if(_resultado)
            {
                lblPopupHeader.Text = "Regla agregada";
                lblPopupBody.Text = "La regla fue agregada exitosamente al sistema.";
                Pop_Alerta.Show();
            }
            else
            {
                lblPopupHeader.Text = "Error al agregar regla";
                lblPopupBody.Text = "Ocurrió un error al intentar agregar la regla al sistema.";
                Pop_Alerta.Show();
            }
            //Page.Response.Redirect(Request.RawUrl);
        }

        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.Url.PathAndQuery);
        }
    }
}