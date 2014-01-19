<%@ Page Title="Asignación Automática de Cupos" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Asignacion.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Asignacion" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolKitManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
    <h2>Asignaci&oacute;n Autom&aacute;tica de Cupos</h2>

    <div class="center" >
        <p>
            Para asignar autom&aacute;ticamente los cupos a grupos para los cuales fue solicitada la inclusi&oacute;n, ejecute 
            el proceso core, que va aplicando las reglas definidas anteriormente.
        </p>
        <p class="submitButton">
            <asp:Button ID="btnAsignar" runat="server" CssClass="submitInput" CommandName="Asignar" 
                Text="Asignar cupos" ValidationGroup="valAsignacion" OnClick="btnAsignar_Click" />
        </p>
        
        <ajaxToolkit:ModalPopupExtender ID="Pop_Alerta" runat="server" OkControlID="btnOK"
            PopupControlID="Pan_Alerta" PopupDragHandleControlID="PopupHeader" Drag="true"
            BackgroundCssClass="ModalPopupBG" TargetControlID="HiddenForModal" >
        </ajaxToolkit:ModalPopupExtender>
        <asp:Button runat="server" ID="HiddenForModal" style="display: none" />
        <asp:Panel ID="Pan_Alerta" style="display:none" runat="server" >
            <div class="modalInsider">
                <div class="PopupHeader">
                    <asp:Label ID="lblPopupHeader" runat="server"></asp:Label>
                </div>
                <div class="PopupBody">
                    <asp:Label ID="lblPopupBody" runat="server"></asp:Label>
                </div>
                <div class="Controls">
                    <input id="btnOK" type="button" value="OK" class="submitInput" />
		        </div>
            </div>
        </asp:Panel>
        
    </div>

</asp:Content>
