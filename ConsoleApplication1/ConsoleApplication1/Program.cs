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
            try
            {
                string pProcedure = "USE INCLUTEC" +
                                    "CREATE PROCEDURE SP_ObtenerDatosEstudiante AS" +
                                    "BEGIN" +
                                    "SELECT * FROM Datos_Estudiante" +
                                    "END";
                IManejadorCodigoSql _Codigo = new ManejadorCodigoSql("Initial Catalog=Inclutec_BD;User Id=InclutecAdmin;Password=inclutec_proyecto");
                _Codigo.CrearProcedimiento(pProcedure);
                Console.WriteLine("Terminado");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace + "\n" + ex.InnerException);
            }
            Console.ReadLine();
        }
    }
}
