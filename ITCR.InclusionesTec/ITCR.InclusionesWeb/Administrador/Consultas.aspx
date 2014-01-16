<%@ Page Title="Consultas" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Consultas</h2>

<div class="center" >
    <p>
        Para hacer alg&uacute;n tipo de consulta, seleccione el tipo que desea realizar. Si desea imprimir el reporte de la consulta 
        realizada, haga click en el bot&oacute;n "Imprimir reporte".
    </p>
    <p>
        <asp:Label ID="lblConsulta" runat="server" AssociatedControlID="ddlConsulta" >Tipo de consulta: </asp:Label>
        <asp:DropDownList ID="ddlConsulta" runat="server" >
            <asp:ListItem Selected="True" Value="Solicitudes" >Solicitudes</asp:ListItem>
            <asp:ListItem Value="Sugerencias" >Sugerencias</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p class="submitButton">
        <asp:Button ID="btnConsultar" runat="server" CssClass="submitInput" CommandName="Consultar" 
            Text="Consultar datos" ValidationGroup="valConsulta" 
            onclick="btnConsultar_Click"/>
    </p>
    <asp:Table ID="tblConsulta" runat="server" ></asp:Table>
</div>
</asp:Content>
