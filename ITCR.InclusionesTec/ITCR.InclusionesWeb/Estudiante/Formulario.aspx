<%@ Page Title="Formulario de inclusión" Language="C#" MasterPageFile="~/Student.master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="ITCR.InclusionesWeb.Estudiante.Formulario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Creación de solicitud de inclusión</h2>

<div class="center">
    <fieldset>
        <legend>Datos Personales</legend>
        <p>
            <asp:Label runat="server" AssociatedControlID="lblNombreCompleto">Nombre Completo: </asp:Label>
            <asp:Label ID="lblNombreCompleto" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label runat="server" AssociatedControlID="lblCarnet" >Carnet: </asp:Label>
            <asp:Label ID="lblCarnet" runat="server" ></asp:Label>
        </p>
        <p>
            <asp:Label runat="server" AssociatedControlID="lblCarrera" >Carrera: </asp:Label>
            <asp:Label ID="lblCarrera" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label runat="server" AssociatedControlID="lblSede" >Sede: </asp:Label>
            <asp:Label ID="lblSede" runat="server" ></asp:Label>
        </p>
        <p>
            <asp:Label runat="server" AssociatedControlID="lblPlan" >Plan: </asp:Label>
            <asp:Label ID="lblPlan" runat="server" ></asp:Label>
        </p>
        <p>
            <asp:Label runat="server" AssociatedControlID="lblCitaMatricula" >Cita de Matr&iacute;cula: </asp:Label>
            <asp:Label ID="lblCitaMatricula" runat="server" ></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblTelefono" runat="server" AssociatedControlID="txtTelefono">Tel&eacute;fono Domicilio:</asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" ></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblCelular" runat="server" AssociatedControlID="txtCelular">Tel&eacute;fono Celular:</asp:Label>
            <asp:TextBox ID="txtCelular" runat="server" CssClass="textEntry" ></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblCorreo" runat="server" AssociatedControlID="txtCorreo" >Correo Electr&oacute;nico:</asp:Label>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="textEntry"></asp:TextBox>
        </p>
    </fieldset>


    <fieldset>
        <legend>Curso</legend>
        <!-- Crear lista de cursos y crear variable que la contenga-->
        <p>
            <asp:Label ID="lblCursos" runat="server" AssociatedControlID="ddlCursos" >Curso por solicitar: </asp:Label>
            <asp:DropDownList ID="ddlCursos" runat="server" 
                OnSelectedIndexChanged="ddlCursos_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Selected="true" Value="-1" Text="-- Escoja un curso --" ></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblCodigoCursoSeleccionado" runat="server"></asp:Label>
        </p>
        <p>
            <h4>Grupos Disponibles:</h4>
            <asp:Table ID="tblGrupos" runat="server" Width="100%" CssClass="tabla">
            </asp:Table>
        </p>
    </fieldset>
    <fieldset>
        <legend>Cursos Matriculados</legend>
        <p id="pCursosMatriculados">
            <asp:Table ID="tblCursosMatriculados" runat="server" Width="100%">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell Text="Curso" Width="10%"/>
                    <asp:TableHeaderCell Text="Grupo" Width="10%"/>
                    <asp:TableHeaderCell Text="Profesor" Width="10%"/>
                    <asp:TableHeaderCell Text="Horario" Width="10%"/>
                    <asp:TableHeaderCell Text="Sede" Width="10%"/>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell Text="Inteligencia Artificial" />
                    <asp:TableCell Text="01" />
                    <asp:TableCell Text="Jorge Vargas" />
                    <asp:TableCell Text="M V 7:30 - 9:20" />
                    <asp:TableCell Text="Cartago" />
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Text="Sistemas Operativos" />
                    <asp:TableCell Text="01" />
                    <asp:TableCell Text="Jorge Vargas" />
                    <asp:TableCell Text="M V 7:30 - 9:20" />
                    <asp:TableCell Text="Cartago" />
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Text="Compiladores e Intérpretes" />
                    <asp:TableCell Text="01" />
                    <asp:TableCell Text="Jorge Vargas" />
                    <asp:TableCell Text="M V 7:30 - 9:20" />
                    <asp:TableCell Text="Cartago" />
                </asp:TableRow>
            </asp:Table>
        </p>
    </fieldset>
    <fieldset>
        <legend>Comentario Adicional</legend>
        <asp:Label ID="lblComentario" runat="server" AssociatedControlID="txtComentario" >Escriba un comentario adicional en caso de ser necesario: </asp:Label>
        <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" ></asp:TextBox>
    </fieldset>
</div>
    <p>
        <asp:Label ID="lblDoyFe" runat="server" >Doy fe que todo lo aqu&iacute; ingresado es correcto y de detectarse alguna falsedad 
            en esta solicitud doy permiso que no se realice ning&uacute;n tr&aacute;mite a mi nombre en este per&iacute;odo.</asp:Label>
    </p>
    <p class="submitButton">
        <asp:Button ID="Button1" runat="server" CssClass="center" CommandName="SendForm" 
            Text="Enviar solicitud" ValidationGroup="valSolicitud" 
            onclick="Button1_Click"/>
    </p>
</asp:Content>
