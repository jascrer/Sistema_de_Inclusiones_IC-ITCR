<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Sugerencias.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Sugerencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Consultar sugerencias de apertura de grupos</h2>
    <div class="center">
        <p>
            En esta p&aacute;gina puede ver sugerencias de apertura de grupos mediante la selecci&oacute;n de distintos filtros. Una vez que los filtros a aplicar 
            han sido escogidos, haga click en el bot&oacute;n de recargar la tabla de sugerencias. Si desea ver los detalles de una sugerencia, haga click en esa 
            opci&oacute;n. Para generar un reporte del resultado de la consulta, haga click en el bot&oacute;n correspondiente.
        </p>
        <fieldset>
            <legend>Sugerencias</legend>
            <p id="filtros">
                <asp:ImageButton ID="btnRecargar" runat="server" AlternateText="Recargar" ToolTip="Recargar" ImageUrl="../Images/table_refresh.png" />
            </p>

            <asp:Table ID="tblSugerencias" runat="server" ></asp:Table>
        </fieldset>
    </div>

</asp:Content>
