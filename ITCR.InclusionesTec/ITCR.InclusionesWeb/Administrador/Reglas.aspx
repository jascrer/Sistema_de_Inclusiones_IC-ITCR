<%@ Page Title="Reglas del Sistema" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Reglas.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Reglas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Reglas del Sistema</h2>
    
    <p>
        En esta p&aacute;gina se gestionan las reglas de negocio del sistema de inclusiones, que son utilizadas en el proceso de asignaci&oacute;n autom&aacute;tica
        para determinar los cupos de los grupos para las solicitudes recibidas.
    </p>

    <div class="center">
        <fieldset>
            <legend>Reglas</legend>
            
            <asp:Table ID="tblReglas" runat="server" ></asp:Table>
            <!--
                * Activar/Desactivar regla
                * Subir
                * Bajar
             -->
        </fieldset>
        <fieldset>
             <legend>Agregar reglas al sistema</legend>
             <p>
                Para agregar una regla a la tabla, llene la siguiente informaci&oacute;n y haga click en el bot&oacute;n de "Agregar regla".
             </p>
             <p>
                <asp:Label ID="lblNombreRegla" runat="server" AssociatedControlID="txtNombreRegla" >Nombre de la regla: </asp:Label>
                <asp:TextBox ID="txtNombreRegla" runat="server"  CssClass="textEntry" ></asp:TextBox>
             </p>
             <p>
                <asp:Label ID="lblNombreProcedimiento" runat="server" AssociatedControlID="txtNombreProcedimiento" >Nombre del procedimiento: </asp:Label>
                <asp:TextBox ID="txtNombreProcedimiento" runat="server" CssClass="textEntry" ></asp:TextBox>
             </p>
             <p class="submitButton">
                    <asp:Button ID="btnAgregarRegla" runat="server" CssClass="submitInput" 
                        CommandName="AgregarRegla" Text="Agregar regla" ValidationGroup="valAgregarRegla" />
             </p>

        </fieldset>
    </div>

</asp:Content>
