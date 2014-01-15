<%@ Page Title="Inicio de Estudiante" Language="C#" MasterPageFile="~/Student.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ITCR.InclusionesWeb.Estudiante.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
    <script src="~/Scripts/jquery-1.10.2.js"></script>
    <script>
        $(function () {
            $("#accordion").accordion();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h3>Bienvenido(a)</h3>

    <!-------------------Centrar------------------------------>
    <div id="accordion">
        <h3>Aprobadas</h3>
        <div>
            
        </div>

        <h3>Pendientes</h3>
        <div>
            
        </div>
        
        <h3>Rechazadas</h3>
        <div>
            
        </div>
        
        <h3>Anuladas</h3>
        <div>
            
        </div>
    </div>


</asp:Content>
