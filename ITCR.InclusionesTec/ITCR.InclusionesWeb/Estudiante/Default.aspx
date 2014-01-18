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
    
    <ajaxToolkit:Accordion ID="acdnSolicitudes" runat="server" CssClass="center" HeaderCssClass="accordionHeader" >
        <Panes>
            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                <Header>Pendientes</Header>
                <Content>
                    -- Sin Solicitudes Pendientes --
                    <asp:Button runat="server" ID="button1" Text="Editar"></asp:Button>
                    
                    <ajaxToolkit:modalpopupextender id="ModalPopupExtender1" runat="server" 
	                    cancelcontrolid="btnCancel" okcontrolid="btnOkay" 
	                    targetcontrolid="button1" popupcontrolid="Panel1" 
	                    popupdraghandlecontrolid="PopupHeader" drag="true" 
	                    backgroundcssclass="ModalPopupBG">
                    </ajaxToolkit:modalpopupextender>

                    <asp:panel id="Panel1" style="display: none" runat="server">
	                    <div class="HellowWorldPopup">
                                    <div class="PopupHeader" id="PopupHeader">Header</div>
                                    <div class="PopupBody">
                                        <p>This is a simple modal dialog</p>
                                    </div>
                                    <div class="Controls">
                                        <input id="btnOkay" type="button" value="Done" />
                                        <input id="btnCancel" type="button" value="Cancel" />
		                    </div>
                            </div>
                    </asp:panel>
                    
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                <Header>Anuladas</Header>
                <Content>
                    -- Sin Solicitudes Anuladas --
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                <Header>Aprobadas</Header>
                <Content>
                    -- Sin Solicitudes Aprobadas --
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                <Header>Rechazadas</Header>
                <Content>
                    -- Sin Solicitudes Rechazadas --
                </Content>
            </ajaxToolkit:AccordionPane>
        </Panes>
    </ajaxToolkit:Accordion>  
</asp:Content>
