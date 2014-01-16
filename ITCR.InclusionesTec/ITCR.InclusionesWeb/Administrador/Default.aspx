<%@ Page Title="Inicio de Administración" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Default" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolKitManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
    <h2>Bienvenido/a</h2>

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
                    

                </Content>
            </ajaxToolkit:AccordionPane>
        </Panes>
    </ajaxToolkit:Accordion>
</asp:Content>
