using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

#region Imported Libraries
using System.Data;
using System.Data.Linq;
using System.Threading;
using System.Data.Entity;
using System.Data.Linq.Mapping;
#endregion

#region Microsoft Practices Libraries
using Microsoft.Practices.EnterpriseLibrary.Data;
#endregion

#region Librerias Inclutec
using ITCR.Ado.ModeloAcDatos;
using ITCR.Ado.ClasesComunes;
using ITCR.MetodosAccesoDatos.Interfaces;
using ITCR.MetodosAccesoDatos.Clases;
#endregion

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Metodos de Login
            /*IMetodosLogin _metLogin = new MetodosLogin();
            Console.WriteLine(_metLogin.VerificarUsuario("200966799","8556",0));*/

            /*Metodos del estudiante*/
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();

            /*bool Existe = _metEstudiante.EstudianteExiste("201030612");
            Console.WriteLine(Existe);
            Estudiante _estAlumno = _metEstudiante.ObtenerDatosEstudiante("201030612", Existe);*/

            Solicitud _solicitud = new Solicitud();
            _solicitud.Id_Solicitud = 7;
            _solicitud.Fec_Creacion = DateTime.Parse("01/15/2014 14:50:00");
            _solicitud.Id_GrupoAceptado = 0;
            _solicitud.Txt_Comentario = "Hola Inclusion";
            _solicitud.txt_Curso = "Proyecto";
            _solicitud.Txt_Estado = "Pendiente";
            _solicitud.Txt_Motivo = "Por que si";
            LinkedList<Grupo> _grupos = _metEstudiante.ObtenerGruposParaInclusion(16);

            foreach (Grupo grupo in _grupos)
            {
                Console.WriteLine(grupo.Id_Grupo);
            }

            Console.WriteLine( _metEstudiante.GuardarGruposSolicitud(_solicitud,_grupos));

            IMetodosAdministrador _metAdministrador = new MetodosAdministrador();
            /*Periodo _objPeriodo = new Periodo();
            _objPeriodo.Fec_Fin = DateTime.Parse("01/15/2014 15:00:00");
            _objPeriodo.Fec_Inicio = DateTime.Parse("01/15/2014 00:00:00");
            _objPeriodo.Num_Anno = 2014;
            _objPeriodo.Num_Periodo = 1;
            _objPeriodo.Txt_Estado = "En Curso";
            _objPeriodo.Txt_Modalidad = "Semestral";
            _metAdministrador.DefinirPeriodoSolicitud(_objPeriodo);*/

            //_metAdministrador.ModificarEstadoPeriodo(1,"Terminado");

            Periodo ultimo = _metAdministrador.UltimoPeriodo();

            //Console.WriteLine(_metEstudiante.GuardarSolicitud("201030612", ultimo.Id_Periodo, _solicitud));

            /*Console.WriteLine(_estAlumno.Nom_Nombre + " " +_estAlumno.Txt_Apellido1 + " " +_estAlumno.Txt_Apellido2 + "\n"
                + _estAlumno.Id_Carnet + "\n" + _estAlumno.Num_Celular + "\n" + _estAlumno.Num_Telefono+ "\n" + _plan.Id_Plan_Estudios + "-" +
                _plan.Nom_Carrera);*/

            Console.ReadLine();
        }
    }
}
