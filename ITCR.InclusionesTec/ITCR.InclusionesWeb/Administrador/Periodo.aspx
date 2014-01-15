<%@ Page Title="Periodo de Recepción de Solicitudes" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Periodo.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Periodo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Per&iacute;odo de Recepci&oacute;n</h2>
        <fieldset>
            <legend>Recepci&oacute;n de Solicitudes</legend>
            <p>
                Para definir el per&iacute;odo de recepci&oacute;n de solicitudes de inclusi&oacute;n, indique las fechas de inicio y fin del mismo. 
            </p>
            
            <label for="Combomodalidad">Modalidad:</label>
            <select id="Combomodalidad" name="Combomodalidad">
                <option value="A">ANUAL</option>
                <option value="B">BIMESTRE</option>
                <option value="C">CUATRIMESTRE</option>
                <option value="H">CENTROS FORMACION HUMANISTICA</option>
                <option value="I">INTENSIVO</option>
                <option value="M">MENSUAL</option>
                <option value="S">SEMESTRE</option>
                <option value="T">TRIMESTRE</option>
                <option value="V">VERANO</option>
            </select>
            <label for="Comboperiodo">Per&iacute;odo:</label>
            <select id="Comboperiodo" name="Comboperiodo">
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
                <option value="6">6</option>
                <option value="7">7</option>
                <option value="8">8</option>
                <option value="9">9</option>
                <option value="10">10</option>
                <option value="11">11</option>
                <option value="12">12</option>
            </select>
            <label for="txtAnno">Año:</label>
            <input type="text" id="txtAnno" name="txtAnno"/>
            <label for="txtFechaInicio">Inicio:</label>
            <input type="date" id="txtFechaInicio" name="txtFechaInicio"/>
            <label for="txtFechaFin">Final:</label>
            <input type="date" id="txtFechaFin" name="txtFechaFin"/>
        </fieldset>
        <!-------------------Centrar------------------------------>
        <input type="submit">


</asp:Content>
