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
    public partial class ConsultaPeriodo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Ado.ClasesComunes.Periodo _periodoActual = new Ado.ClasesComunes.Periodo();
            IMetodosAdministrador _metAdministrador = new MetodosAdministrador();
            _periodoActual = _metAdministrador.UltimoPeriodo();
            if (_periodoActual != null)
            {
                LinkedList<string> _encabezados = new LinkedList<string>();
                _encabezados.AddLast("Identificación");
                _encabezados.AddLast("Fecha de Inicio");
                _encabezados.AddLast("Fecha de Fin");
                _encabezados.AddLast("Estado");
                _encabezados.AddLast("Modalidad");
                _encabezados.AddLast("Año");
                _encabezados.AddLast("Número de Periodo");
                TableHeaderRow _encabezado = new TableHeaderRow();
                foreach (var _elemento in _encabezados)
                {
                    TableHeaderCell _celda = new TableHeaderCell();
                    _celda.Text = _elemento;
                    _encabezado.Cells.Add(_celda);
                }

                LinkedList<string> _periodo = new LinkedList<string>();
                _periodo.AddLast(_periodoActual.Id_Periodo.ToString());
                _periodo.AddLast(_periodoActual.Fec_Inicio.Date.ToString());
                _periodo.AddLast(_periodoActual.Fec_Fin.Date.ToString());
                _periodo.AddLast(_periodoActual.Txt_Estado);
                _periodo.AddLast(_periodoActual.Txt_Modalidad);
                _periodo.AddLast(_periodoActual.Num_Anno.ToString());
                _periodo.AddLast(_periodoActual.Num_Periodo.ToString());
                TableRow _fila = new TableRow();
                foreach (var _elemento in _periodo)
                {
                    TableCell _celda = new TableCell();
                    _celda.Text = _elemento;
                    _fila.Cells.Add(_celda);
                }
                //Lleno tabla
                tblPeriodo.Rows.Add(_encabezado);
                tblPeriodo.Rows.Add(_fila);
                

            }
            else
            {
                //Agrego Label que diga que no hay un periodo de recepcion en curso actualmente.
                lblSinPeriodo.Text = "-- El sistema no tiene actualmente un periodo de recepción de solicitudes en curso actualmente. --";
            }
        }
    }
}