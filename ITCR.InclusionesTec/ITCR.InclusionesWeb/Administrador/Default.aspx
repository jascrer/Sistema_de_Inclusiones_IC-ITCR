<%@ Page Title="Inicio de Administración" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Default" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolKitManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
    <h2>Bienvenido(a)</h2>

    <p>
        Bienvenido al sistema automatizado de inclusiones. En esta p&aacute;gina puede gestionar las excepciones y avisos del sistema.
        Si desea ejecutar alguno de los procesos de inclusi&oacute;n, como lo son definir un periodo de recepci&oacute;n de solicitudes, 
        asignar autom&aacute;ticamente cupos o consultar sugerencias, puede hacerlo haciendo click en las opciones que aparecen en el men&uacute;.
    </p>

    <ajaxToolkit:Accordion ID="acdnAvisosExcepciones" runat="server" CssClass="center" HeaderCssClass="accordionHeader" >
        <Panes>
            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                <Header>Avisos</Header>
                <Content>
                    <p>
                        No hay avisos pendientes de revisi&oacute;n.
                    </p>
                    <asp:Table ID="tblAvisos" runat="server" ></asp:Table>
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                <Header>Excepciones</Header>
                <Content>
                    <p>
                        Agregue las excepciones manualmente. Esta secci&oacute;n solo est&aacute; disponible mientras el proceso de
                            asignaci&oacute;n autom&aacute;tica no haya sido ejecutado.
                    </p>

                    <p>
                        <asp:Label ID="lblCarnet" runat="server" AssociatedControlID="txtCarnet" >Digite el carnet del estudiante: </asp:Label>
                        <asp:TextBox ID="txtCarnet" runat="server" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqCarnet" runat="server" ControlToValidate="txtCarnet"
                            CssClass="failureNotification" ErrorMessage="El carnet es obligatorio."
                            ToolTip="El carnet es obligatorio." ValidationGroup="valAgregarExcepcion">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblCurso" runat="server" AssociatedControlID="ddlCurso" >Seleccione el c&oacute;digo del curso:</asp:Label>
                        <asp:DropDownList ID="ddlCurso" runat="server" ></asp:DropDownList>
                    </p>
                    <p>
                        <asp:Label ID="lblGrupo" runat="server" AssociatedControlID="ddlGrupo" >Digite el c&oacute;digo del curso:</asp:Label>
                        <asp:DropDownList ID="ddlGrupo" runat="server" ></asp:DropDownList>
                    </p>
                    <span class="failureNotification">
                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="valSum" runat="server" CssClass="failureNotification" ValidationGroup="valAgregarExcepcion" />

                    <p class="submitButton">
                        <asp:Button ID="btnAgregarExcepcion" runat="server" CssClass="submitInput" CommandName="AgregarExcepcion" 
                            Text="Agregar excepción" ValidationGroup="valAgregarExcepcion" OnClick="btnAgregarExcepcion_Click" />
                    </p>

                    <!-- ACA VA LA TABLA DE EXCEPCIONES -->
                    <asp:Table ID="tblExcepciones" runat="server" Width="100%">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell Text="Carnet" Width="10%"/>
                            <asp:TableHeaderCell Text="Curso" Width="10%"/>
                            <asp:TableHeaderCell Text="Grupo" Width="10%"/>
                            <asp:TableHeaderCell Width="10%"/>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell Text="200813008" />
                            <asp:TableCell Text="IC7811" />
                            <asp:TableCell Text="2" />
                            <asp:TableCell> <asp:Button runat="server" ID="butEdit" Text="Editar" /> <asp:Button runat="server" ID="butDel" Text="Eliminar" /> </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Text="200966799" />
                            <asp:TableCell Text="IC8039" />
                            <asp:TableCell Text="40" />
                            <asp:TableCell> <asp:Button runat="server" ID="Button1" Text="Editar" /> <asp:Button runat="server" ID="Button2" Text="Eliminar" /> </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                </Content>
            </ajaxToolkit:AccordionPane>
        </Panes>
    </ajaxToolkit:Accordion>
</asp:Content>
