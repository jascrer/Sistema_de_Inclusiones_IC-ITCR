<%@ Page Title="Inicio de Administración" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Default" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Bienvenido/a</h2>

    <div class="center" >
        <p>
            Bienvenido al sistema automatizado de inclusiones. En esta p&aacute;gina puede gestionar las excepciones y avisos del sistema.
            Si desea ejecutar alguno de los procesos de inclusi&oacute;n, como lo son definir un periodo de recepci&oacute;n de solicitudes, 
            asignar autom&aacute;ticamente cupos o consultar sugerencias, puede hacerlo haciendo click en las opciones que aparecen en el men&uacute;.
        </p>
    </div>
    
</asp:Content>
