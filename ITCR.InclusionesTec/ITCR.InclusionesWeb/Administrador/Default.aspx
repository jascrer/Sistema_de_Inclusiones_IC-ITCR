﻿<%@ Page Title="Inicio de Administración" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ITCR.InclusionesWeb.Administrador.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h3>Bienvenido(a)</h3>

    <!-------------------Centrar------------------------------>
    <div id="accordion">
        <h3>Avisos</h3>
        <div>
            
        </div>

        <h3>Excepciones</h3>
        <div>
        <p>Agregue las excepciones manualmente. Esta secci&oacute;n solo est&aacute; disponible mientras el proceso de
            asignaci&oacute;n autom&aacute;tica no haya sido ejecutado.</p>
            <div id="excepciones">
                <form id="frmNuevaExcepcion">
                    <label for="txtCarnetEstudiante">Digite el carnet del estudiante:</label>
                    <input type="text" id="txtCarnetEstudiante" name="txtCarnetEstudiante" value="" /><br/>
                    <label for="txtCodigoCurso">Digite el c&oacute;digo del curso:</label>
                    <input type="text" id="txtCodigoCurso" name="txtCodigoCurso" value="" /><br/>
                    <label for="txtNumeroGrupo">Digite el n&uacute;mero del grupo:</label>
                    <input type="text" id="txtNumeroGrupo" name="txtNumeroGrupo" value="" /><br/>
                    <input type="submit" id="sbmtAgregarExcepcion" name="sbmtAgregarExcepcion" form="frmNuevaExcepcion" value="Agregar" />
                </form>
                <br/>
                <center><table id="table">
                            <!-- Cabecera de la tabla -->
                            <thead>
                                <tr>
                                    <th>Carnet</th>
                                    <th>Curso</th>
                                    <th>Grupo</th>
                                    <th>&nbsp;</th>
                                    <th>&nbsp;</th>
                                </tr>
                            </thead>
                    
                            @*<!-- Cuerpo de la tabla con los campos -->
	                <tbody>
 
		                <!-- fila base para clonar y agregar al final -->
		                <tr class="fila-base">
			                <td><input type="text" class="Carnet" /></td>
		                    <td><input type="text" class="Curso" /></td>
                            <td><input type="text" class="Grupo" /></td>
			                
			                <td class="eliminar">Eliminar</td>
		                </tr>
	                    <!-- fin de código: fila base -->
                        
                        <!-- Fila de ejemplo -->
		                <tr>
			                <td><input type="text" class="Carnet" /></td>
		                    <td><input type="text" class="Curso" /></td>
                            <td><input type="text" class="Grupo" /></td>
			                
			                <td class="eliminar">Eliminar</td>
		                </tr>
		                <!-- fin de código: fila de ejemplo -->
 
	                    <!-- Botón para agregar filas -->
                        <input type="button" id="agregar" value="Agregar Excepción" />
 
	                </tbody>
                @*<table class="footable-sortable">
                  <thead>
                    <tr>
                      <th>Name</th>
                      <th data-hide="phone,tablet">Phone</th>
                      <th data-hide="phone,tablet">Email</th>
                    </tr>
                  </thead>*@
                            <tbody>
                                <tr>
                                    <td>200813008</td>
                                    <td>INVESTIGACION DE OPERACIONES</td>
                                    <td>2</td>
                                    <td><a href="">Editar</a></td>
                                    <td><a href="">Eliminar</a></td>
                                </tr>
                                <tr>
                                    <td>200966799</td>
                                    <td>PROYECTO</td>
                                    <td>1</td>
                                    <td><a href="">Editar</a></td>
                                    <td><a href="">Eliminar</a></td>
                                </tr>
                                <tr>
                                    <td>201030612</td>
                                    <td>REDES LOCALES</td>
                                    <td>40</td>
                                    <td><a href="">Editar</a></td>
                                    <td><a href="">Eliminar</a></td>
                                </tr>
                            </tbody>
                        </table>
                        </center>
            </div>
        </div>
    </div>


</asp:Content>