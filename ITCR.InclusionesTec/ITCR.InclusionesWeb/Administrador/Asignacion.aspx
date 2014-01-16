<%@ Page Title="Asignación Automática de Cupos" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Asignacion.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Asignacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Asignaci&oacute;n Autom&aacute;tica de Cupos</h2>

    <div class="center" >
        <p>
            Para asignar autom&aacute;ticamente los cupos a grupos para los cuales fue solicitada la inclusi&oacute;n, ejecute 
            el proceso core, que va aplicando las reglas definidas anteriormente.
        </p>
        <p class="submitButton">
            <asp:Button ID="btnAsignar" runat="server" CssClass="submitInput" CommandName="Asignar" 
                Text="Asignar cupos" ValidationGroup="valAsignacion"/>
        </p>
    </div>

</asp:Content>
