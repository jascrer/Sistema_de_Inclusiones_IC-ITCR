<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ITCR.InclusionesWeb._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Bienvenido
    </h2>
    
    <p>
        Bienvenido al sistema automatizado de inclusiones IncluTec. Para hacer uso del sistema
        indique su tipo de usuario, nombre de usuario y contrase&ntilde;a.
    </p>

    <div class="accountInfo center">
        <fieldset class="login">
            <legend>Información de cuenta</legend>
            <p>
                <asp:Label ID="lblTipoUsuario" runat="server" AssociatedControlID="ddlTipoUsuario">Tipo de usuario:</asp:Label>
                <asp:DropDownList ID="ddlTipoUsuario" runat="server">
                    <asp:ListItem Selected="True" Value="0" >Estudiante</asp:ListItem>
                    <asp:ListItem Value="1">Funcionario</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="lblNombreUsuario" runat="server" AssociatedControlID="txtNombreUsuario">Nombre de usuario:</asp:Label>
                <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqNombreUsuario" runat="server" ControlToValidate="txtNombreUsuario"
                    CssClass="failureNotification" ErrorMessage="El nombre de usuario es obligatorio."
                    ToolTip="El nombre de usuario es obligatorio." ValidationGroup="valInicioSesion">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblContrasena" runat="server" AssociatedControlID="txtContrasena">Contrase&ntilde;a:</asp:Label>
                <asp:TextBox ID="txtContrasena" runat="server" CssClass="passwordEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqContrasena" runat="server" ControlToValidate="txtContrasena"
                    CssClass="failureNotification" ErrorMessage="La contraseña es obligatoria."
                    ToolTip="La contraseña es obligatoria." ValidationGroup="valInicioSesion">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:CheckBox ID="chbRecordarme" runat="server" />
                <asp:Label ID="lblRecordarme" runat="server" AssociatedControlID="chbRecordarme" CssClass="inline">Recordarme en esta computadora</asp:Label>
            </p>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="btnInicioSesion" runat="server" CssClass="submitInput" CommandName="Login" Text="Iniciar sesión" ValidationGroup="valInicioSesion"/>
        </p>
    </div>
</asp:Content>
