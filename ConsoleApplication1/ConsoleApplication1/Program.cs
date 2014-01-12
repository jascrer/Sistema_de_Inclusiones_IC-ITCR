using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

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
            /*
             * Manager de la conexion
             * Siempre debe haber uno para que se de la conexion con la base de datos.
             * Ya sea para leer o escribir es necesario.
             * 
            Inclutec_BDEntities _dbManager = new Inclutec_BDEntities();
            
            /*
             * Escritura en la base de datos.
             *

            //Paso 1: Se crea el objeto y se llena la informacion del mismo.
            SIFPlanEstudio plan = new SIFPlanEstudio();
            plan.id_PlanEstudios = 1;
            plan.nom_carrera = "Compu";
            //_sifeEstudiante.num_plan_estudios = 409;

            //Paso 2: Se guarda el objeto, usando el metodo correspondiente 
            //        del manager y a continuacion se invoca el metodo 
            //        SaveChanges() que ejecuta el commit de la operacion.
            _dbManager.AddToSIFPlanEstudios(plan);
            _dbManager.SaveChanges();

            /*
             * Lectura de la base de datos
             * Solo se deben hacer lecturas simples, nada complicadas.
             *

            //Se utiliza una lectura en Linq que se aplica en el property deseado del
            //Manager
            //Ejemplos: http://msdn.microsoft.com/es-es/library/vstudio/bb397933(v=vs.100).aspx
            var _PruebaLinq = from planes in _dbManager.SIFPlanEstudios 
                              select planes;

            //Escritura de comprobacion
            foreach (SIFPlanEstudio planc in _PruebaLinq)
            {
                Console.WriteLine(planc.nom_carrera);
            }

            //Crea una espera de teclado para terminar la aplicacion
            Console.ReadLine();*/
            /*
            wsDar.AdmisionyRegistro _darManager = new wsDar.AdmisionyRegistro();
            DataSet _PruebaDatos = _darManager.CITASMATRICULA_Buscar("201030612", "O", null, "2013", "S", "1");
            foreach (DataRow dr in _PruebaDatos.Tables[0].Rows)
            {
                Console.WriteLine(dr["IDE_ESTUDIANTE"].ToString() + " - " + dr["IDE_MATRICULA"].ToString() +
                    "\n" + dr["FEC_MATRICULA"].ToString() + " - " + dr["NUM_PROMEDIO"].ToString() +
                    "\n" + dr["NUM_DIFGAN_PER"].ToString() + " - " + dr["NUM_GANADOS"].ToString() +
                    "\n" + dr["NUM_PERDIDOS"].ToString() + " - " + dr["NUM_ANO"].ToString() +
                    "\n" + dr["IDE_MODALIDAD"].ToString() + " - " + dr["IDE_PER_MOD"].ToString() +
                    "\n" + dr["FEC_GENERACION"].ToString() + " - " + dr["IDE_USUARIO"].ToString());
            }
            
            IMetodosEstudiante _metEstudiante = new MetodosEstudiante();
            PlanEstudios plan = _metEstudiante.ObtenerPlanEstudios("201030612", true);
            Console.WriteLine(plan.Id_Plan_Estudios);*/

            XmlDocument _xmlEditor = new XmlDocument();
            _xmlEditor.Load("OrdenReglas.xml");

            XmlNodeList nodeList = _xmlEditor.SelectNodes("//param");
            foreach (XmlNode node in nodeList)
            {
                Console.WriteLine(node.Attributes["nombre"].Value);
            }

            Console.ReadLine();
        }
    }
}
