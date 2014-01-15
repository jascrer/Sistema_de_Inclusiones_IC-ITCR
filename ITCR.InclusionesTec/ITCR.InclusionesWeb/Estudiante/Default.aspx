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
                    Bla
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                <Header>Anuladas</Header>
                <Content>
                    Bla
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                <Header>Aprobadas</Header>
                <Content>
                    Bla
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                <Header>Rechazadas</Header>
                <Content>
                    Bla
                </Content>
            </ajaxToolkit:AccordionPane>
        </Panes>
    </ajaxToolkit:Accordion>  
</asp:Content>
