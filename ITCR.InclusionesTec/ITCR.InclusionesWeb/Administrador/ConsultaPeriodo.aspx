<%@ Page Title="Consultar Periodo" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="ConsultaPeriodo.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.ConsultaPeriodo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Consultar periodos de recepci&oacute;n</h2>
    <div class="center">
    
        <p>
            La siguiente tabla muestra el periodo actual de recepci&oacute;n de solicitudes de inlusi&oacute;n.
        </p>
        <p class="center">
            <asp:Label ID="lblSinPeriodo" runat="server" ></asp:Label>
        </p>
        <asp:Table ID="tblPeriodo" runat="server" CssClass="tabla" ></asp:Table>

    </div>

</asp:Content>
