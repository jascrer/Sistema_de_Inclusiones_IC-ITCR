﻿<%@ Page Title="Notificaciones" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Notificaciones.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Notificaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<!-------------------Centrar y Dar Formato------------------------------>
    <h2>Notificar Resultados</h2>
    <p>
        Para notificar a los estudiantes que enviaron el formulario de solicitud y a los profesores asociados a los grupos correspondientes, los resultados de la asignaci&oacute;n autom&aacute;tica de cupos del per&iacute;odo, haga click en el bot&oacute;n "Notificar resultados" que se encuentra en esta p&aacute;gina.
    </p>
        <!-------------------Centrar------------------------------>
    <input id="botonNotificar" name="botonNotificar" type="submit" value="Notificar Resultados">


</asp:Content>