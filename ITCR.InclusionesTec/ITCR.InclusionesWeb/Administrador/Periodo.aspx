<%@ Page Title="Periodo de Recepción de Solicitudes" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Periodo.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Periodo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Per&iacute;odo de Recepci&oacute;n</h2>

<div class="center">
    <fieldset>
        <legend>Recepci&oacute;n de Solicitudes</legend>
        <p>
            Para definir el per&iacute;odo de recepci&oacute;n de solicitudes de inclusi&oacute;n, indique las fechas de inicio y fin del mismo. 
        </p>
        
        <p>
            <asp:Label ID="lblModalidad" runat="server" AssociatedControlID="ddlModalidad" >Modalidad: </asp:Label>
            <asp:DropDownList ID="ddlModalidad" runat="server" >
                <asp:ListItem Selected="True" Value="A" >Anual</asp:ListItem>
                <asp:ListItem Value="B" >Bimestre</asp:ListItem>
                <asp:ListItem Value="C" >Cuatrimestre</asp:ListItem>
                <asp:ListItem Value="H" >Centros Formaci&oacute;n Human&iacute;stica</asp:ListItem>
                <asp:ListItem Value="I" >Intensivo</asp:ListItem>
                <asp:ListItem Value="M" >Mensual</asp:ListItem>
                <asp:ListItem Value="S" >Semestre</asp:ListItem>
                <asp:ListItem Value="T" >Trimestre</asp:ListItem>
                <asp:ListItem Value="V" >Verano</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="lblPeriodo" runat="server" AssociatedControlID="ddlPeriodo" >Periodo: </asp:Label>
            <asp:DropDownList ID="ddlPeriodo" runat="server" >
                <asp:ListItem Selected="True" Value="1" >1</asp:ListItem>
                <asp:ListItem Value="2" >2</asp:ListItem>
                <asp:ListItem Value="3" >3</asp:ListItem>
                <asp:ListItem Value="4" >4</asp:ListItem>
                <asp:ListItem Value="5" >5</asp:ListItem>
                <asp:ListItem Value="6" >6</asp:ListItem>
                <asp:ListItem Value="7" >7</asp:ListItem>
                <asp:ListItem Value="8" >8</asp:ListItem>
                <asp:ListItem Value="9" >9</asp:ListItem>
                <asp:ListItem Value="10" >10</asp:ListItem>
                <asp:ListItem Value="11" >11</asp:ListItem>
                <asp:ListItem Value="12" >12</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="lblAnio" runat="server" AssociatedControlID="txtAnio" >A&ntilde;o: </asp:Label>
            <asp:TextBox ID="txtAnio" runat="server" TextMode="Number" ></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblFechaInicio" runat="server" AssociatedControlID="txtFechaInicio" >Fecha de inicio: </asp:Label>
            <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" ></asp:TextBox>

            <asp:Label ID="lblFechaFinal" runat="server" AssociatedControlID="txtFechaFinal" >Fecha de fin: </asp:Label>
            <asp:TextBox ID="txtFechaFinal" runat="server" TextMode="Date" ></asp:TextBox>
        </p>
    </fieldset>
</p>
</div>
<p class="submitButton">
    <asp:Button ID="btnDefinirPeriodo" runat="server" CssClass="submitInput" CommandName="DefPeriodo" 
        Text="Definir periodo" ValidationGroup="valPeriodo"/>
</p>

</asp:Content>
