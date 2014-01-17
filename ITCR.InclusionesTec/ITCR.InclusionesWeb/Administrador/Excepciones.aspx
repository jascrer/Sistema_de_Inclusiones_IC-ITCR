<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Excepciones.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Excepciones" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Gestionar excepciones de asignaci&oacute;n</h2>
    <div class="center">
        <fieldset>
            <p>
                Agregue las excepciones manualmente. Esta secci&oacute;n solo est&aacute; disponible mientras el proceso de
                    asignaci&oacute;n autom&aacute;tica no haya sido ejecutado.
            </p>

            

            <!-- ACA VA LA TABLA DE EXCEPCIONES -->

            <asp:GridView ID="tbl" runat="server" CssClass="tabla" >
                
            </asp:GridView>

            <asp:Table ID="tblExcepciones" runat="server" CssClass="tabla" >
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell Text="Carnet"/>
                    <asp:TableHeaderCell Text="Curso"/>
                    <asp:TableHeaderCell Text="Grupo"/>
                    <asp:TableHeaderCell />
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell Text="200813008" />
                    <asp:TableCell Text="IC7811" />
                    <asp:TableCell Text="2" />
                    <asp:TableCell>
                        <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="../Images/table_edit.png" />
                        <asp:ImageButton ID="btnBorrar" runat="server" ImageUrl="../Images/table_row_delete.png" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Text="200966799" />
                    <asp:TableCell Text="IC8039" />
                    <asp:TableCell Text="40" />
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../Images/table_edit.png" />
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../Images/table_row_delete.png" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

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

                <asp:Label ID="lblGrupo" runat="server" AssociatedControlID="ddlGrupo" >Digite el c&oacute;digo del curso:</asp:Label>
                <asp:DropDownList ID="ddlGrupo" runat="server" ></asp:DropDownList>
            </p>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="valSum" runat="server" CssClass="failureNotification" ValidationGroup="valAgregarExcepcion" />

            <p class="submitButton">
                <asp:Button ID="btnAgregarExcepcion" runat="server" CssClass="submitInput" CommandName="AgregarExcepcion" 
                    Text="Agregar excepción" ValidationGroup="valAgregarExcepcion"  />
            </p>

        </fieldset>
    </div>

</asp:Content>
