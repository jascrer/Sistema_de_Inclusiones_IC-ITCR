using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            SIFEstudiante _sifeEstudiante = new SIFEstudiante();
            _sifeEstudiante.id_Carnet = "201030612";
            _sifeEstudiante.nom_nombre = "Arnoldo";
            _sifeEstudiante.txt_apellido_1 = "Segura";
            _sifeEstudiante.txt_apellido_2 = "Campos";
            _sifeEstudiante.num_telefono = "25771122";
            _sifeEstudiante.num_celular = "83370577";
            _sifeEstudiante.dir_email = "jarnoldo2809@gmail.com";
            _sifeEstudiante.num_plan_estudios = 409;

            //Paso 2: Se guarda el objeto, usando el metodo correspondiente 
            //        del manager y a continuacion se invoca el metodo 
            //        SaveChanges() que ejecuta el commit de la operacion.
            _dbManager.AddToSIFEstudiantes(_sifeEstudiante);
            _dbManager.SaveChanges();

            /*
             * Lectura de la base de datos
             * Solo se deben hacer lecturas simples, nada complicadas.
             * 

            //Se utiliza una lectura en Linq que se aplica en el property deseado del
            //Manager
            //Ejemplos: http://msdn.microsoft.com/es-es/library/vstudio/bb397933(v=vs.100).aspx
            var _PruebaLinq = from estudiantes in _dbManager.SIFEstudiantes 
                              select estudiantes;

            //Escritura de comprobacion
            foreach (SIFEstudiante student in _PruebaLinq)
            {
                Console.WriteLine(student.id_Carnet + "-" + student.nom_nombre);
            }

            //Crea una espera de teclado para terminar la aplicacion
            Console.ReadLine();*/

            wsDar.AdmisionyRegistro _darManager = new wsDar.AdmisionyRegistro();
            DataSet _PruebaDatos = _darManager.IEMAFCURRI_Buscar("201030612","CA","S","2","2012");
            foreach (DataRow dr in _PruebaDatos.Tables[0].Rows)
            {
                Console.WriteLine(dr["IDE_ESTUDIANTE"].ToString() + " - " + dr["IDE_SEDE"].ToString() +
                    "\n" + dr["IDE_PLAN"].ToString() + " - " + dr["IDE_MATERIA"].ToString() +
                    "\n" + dr["NUM_ANO"].ToString() + " - " + dr["IDE_MODALIDAD"].ToString() +
                    "\n" + dr["IDE_PER_MOD"].ToString() + " - " + dr["IDE_GRUPO"].ToString() +
                    "\n" + dr["IDE_SED_GRU"].ToString() + " - " + dr["NUM_NOTA"].ToString() +
                    "\n" + dr["IDE_EST_CUR"].ToString());
            }

            //IMetodosEstudiante _metEstudiante = new MetodosEstudiante();


            Console.ReadLine();
        }
    }
}
