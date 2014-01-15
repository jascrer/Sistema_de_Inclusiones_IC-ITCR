<%@ Page Title="Consultas" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Consultas</h2>

<p>Para hacer alg&uacute;n tipo de consulta, seleccione el tipo que desea realizar. Si desea imprimir el reporte de la consulta realizada, haga click en el bot&oacute;n "Imprimir reporte".</p>
<div>
    <label for="drpConsulta">Consulta:</label>
    <select id="drpConsulta" name="drpConsulta" class="dropdown" onchange="fnMostrarTabla('this.value')">
        <option value="0">Solicitudes</option>
        <option value="1">Sugerencias</option>
    </select>
    <input type="submit" id="btnImprimirReporte" name="btnImprimirReporte" />
</div>
<div id="tablaDinamica" class="tablaDinamica"></div>


</asp:Content>
