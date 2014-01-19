<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Excepciones.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Excepciones" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <ajaxToolkit:ToolkitScriptManager ID="ToolKitManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>

    <h2>Gestionar excepciones de asignaci&oacute;n</h2>
    
    <p>
        Agregue las excepciones manualmente. Esta secci&oacute;n solo est&aacute; disponible mientras el proceso de
            asignaci&oacute;n autom&aacute;tica no haya sido ejecutado.
    </p>
    <div class="center">
        <ajaxToolkit:ModalPopupExtender ID="Pop_Alerta" runat="server" OkControlID="btnOK"
                PopupControlID="Pan_Alerta" PopupDragHandleControlID="PopupHeader" Drag="true"
                BackgroundCssClass="ModalPopupBG" TargetControlID="HiddenForModal" >
        </ajaxToolkit:ModalPopupExtender>
        <asp:Button runat="server" ID="HiddenForModal" style="display: none" />
        <asp:Panel ID="Pan_Alerta" style="display:none" runat="server" >
            <div class="modalInsider">
                <asp:ImageButton ID="btnCloseModal" runat="server" ImageUrl="../Images/close_modal.png" OnClick="btnCloseModal_Click" />
                <div class="PopupHeader">
                    <asp:Label ID="lblPopupHeader" runat="server"></asp:Label>
                </div>
                <div class="PopupBody">
                    <asp:Label ID="lblPopupBody" runat="server"></asp:Label>
                </div>
                <div class="Controls">
                    <input id="btnOK" type="button" value="OK" style="display:none" class="submitInput"/>
		        </div>
            </div>
        </asp:Panel>

            <!-- ACA VA LA TABLA DE EXCEPCIONES -->
            <asp:Table ID="tblExcepciones" runat="server" CssClass="tabla"></asp:Table>

        <fieldset>
            <legend>Agregar excepciones al sistema</legend>
            <p>
                <asp:Label ID="lblCarnet" runat="server" AssociatedControlID="txtCarnet" >Digite el carnet del estudiante: </asp:Label>
                <asp:TextBox ID="txtCarnet" runat="server" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqCarnet" runat="server" ControlToValidate="txtCarnet"
                    CssClass="failureNotification" ErrorMessage="El carnet del estudiate es obligatorio."
                    ToolTip="El carnet del estudiate es obligatorio." ValidationGroup="valAgregarExcepcion">*</asp:RequiredFieldValidator>
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
                    Text="Agregar excepción" ValidationGroup="valAgregarExcepcion" OnClick="btnAgregarExcepcion_Click"  />
            </p>

            

        </fieldset>
    </div>

</asp:Content>
