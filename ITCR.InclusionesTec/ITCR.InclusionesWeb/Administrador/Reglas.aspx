<%@ Page Title="Reglas del Sistema" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Reglas.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Reglas" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <ajaxToolkit:ToolkitScriptManager ID="ToolKitManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>

    <h2>Reglas del Sistema</h2>
    
    <p>
        En esta p&aacute;gina se gestionan las reglas de negocio del sistema de inclusiones, que son utilizadas en el proceso de asignaci&oacute;n autom&aacute;tica
        para determinar los cupos de los grupos para las solicitudes recibidas.
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
 
        <asp:Table ID="tblReglas" runat="server" CssClass="tabla" ></asp:Table>

        <fieldset>
             <legend>Agregar reglas al sistema</legend>
             <p>
                Para agregar una regla a la tabla, llene la siguiente informaci&oacute;n y haga click en el bot&oacute;n de "Agregar regla".
             </p>
             <p>
                <asp:Label ID="lblNombreRegla" runat="server" AssociatedControlID="txtNombreRegla" >Nombre de la regla: </asp:Label>
                <asp:TextBox ID="txtNombreRegla" runat="server"  CssClass="textEntry" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqNombre" runat="server" ControlToValidate="txtNombreRegla"
                CssClass="failureNotification" ErrorMessage="El nombre es obligatorio."
                ToolTip="El nombre es obligatorio." ValidationGroup="valAgregarRegla">*</asp:RequiredFieldValidator>
             </p>
             <p>
                <asp:Label ID="lblNombreProcedimiento" runat="server" AssociatedControlID="txtNombreProcedimiento" >Nombre del procedimiento: </asp:Label>
                <asp:TextBox ID="txtNombreProcedimiento" runat="server" CssClass="textEntry" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqProcedimiento" runat="server" ControlToValidate="txtNombreProcedimiento"
                CssClass="failureNotification" ErrorMessage="El procedimiento almacenado es obligatorio."
                ToolTip="El procedimiento almacenado es obligatorio." ValidationGroup="valAgregarRegla">*</asp:RequiredFieldValidator>
             </p>
             <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
             </span>
             <asp:ValidationSummary ID="valSum" runat="server" CssClass="failureNotification" ValidationGroup="valAgregarRegla" />
             <p class="submitButton">
                    <asp:Button ID="btnAgregarRegla" runat="server" CssClass="submitInput" OnClick="btnAgregarRegla_Click"
                        CommandName="AgregarRegla" Text="Agregar regla" ValidationGroup="valAgregarRegla" />
             </p>

        </fieldset>
    </div>

</asp:Content>
