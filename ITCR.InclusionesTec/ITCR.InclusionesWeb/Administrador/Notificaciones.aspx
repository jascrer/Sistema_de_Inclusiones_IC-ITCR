<%@ Page Title="Notificaciones" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Notificaciones.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Notificaciones" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<ajaxToolkit:ToolkitScriptManager ID="ToolKitManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>

<h2>Notificar Resultados del Proceso</h2>

<div class="center" >
    <p>
        Para notificar a los estudiantes que enviaron el formulario de solicitud y a los profesores asociados a los grupos correspondientes, los resultados de la asignaci&oacute;n autom&aacute;tica de cupos del per&iacute;odo, haga click en el bot&oacute;n "Notificar resultados" que se encuentra en esta p&aacute;gina.
    </p>
    <p class="submitButton">
        <asp:Button ID="btnNotificar" runat="server" CssClass="submitInput" CommandName="Notificar" 
            Text="Notificar resultados" ValidationGroup="valNotificacion" OnClick="btnNotificar_Click" />
    </p>

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

</div>
</asp:Content>
