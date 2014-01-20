<%@ Page Title="Inicio de Estudiante" Language="C#" MasterPageFile="~/Student.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ITCR.InclusionesWeb.Estudiante.Default" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Bienvenido/a</h2>

    <p>
        Bienvenido al sistema automatizado de inclusiones. En esta p&aacute;gina puede revisar todas las solicitudes de inclusi&oacute;n 
        relacionadas con el n&uacute;mero de carnet ingresado, as&iacute; como los detalles de cada una. Para crear una nueva solicitud, 
        abra el formulario en el men&uacute; de la p&aacute;gina y env&iacute;e el formulario una vez completada la informaci&oacute;n.
    </p>

    <ajaxToolkit:ToolkitScriptManager ID="ToolKitManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
    
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
    
    <ajaxToolkit:Accordion ID="acdnSolicitudes" runat="server" CssClass="center" HeaderCssClass="accordionHeader" >
        <Panes>
            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                <Header>Pendientes</Header>
                <Content>
                    <asp:Table ID="tblPendientes" runat="server" CssClass="tabla"></asp:Table>
                    <asp:Button runat="server" ID="button1" Text="Editar"></asp:Button>
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                <Header>Anuladas</Header>
                <Content>
                    <asp:Table ID="tblAnuladas" runat="server" CssClass="tabla"></asp:Table>
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                <Header>Aprobadas</Header>
                <Content>
                    <asp:Table ID="tblAprobadas" runat="server" CssClass="tabla"></asp:Table>
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                <Header>Rechazadas</Header>
                <Content>
                    <asp:Table ID="tblReprobadas" runat="server" CssClass="tabla"></asp:Table>
                </Content>
            </ajaxToolkit:AccordionPane>
        </Panes>
    </ajaxToolkit:Accordion>  
</asp:Content>
