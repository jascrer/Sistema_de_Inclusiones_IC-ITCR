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
            wsDar.AdmisionyRegistro _admin = new wsDar.AdmisionyRegistro();
            /*DataSet _tipoMatricula = _admin.TIPOS_MATRICULA_Buscar();
            foreach (DataRow _row in _tipoMatricula.Tables[0].Rows)
            {
                Console.WriteLine(_row["IDE_MATRICULA"].ToString() + _row["DSC_MATRICULA"].ToString());
            }
            */
            DataSet _citasMatricula = _admin.CITASMATRICULA_Buscar("201030612", "1", "", "2013", "S", "1");
            Console.WriteLine(_citasMatricula.Tables[0].Rows.Count);
            foreach (DataRow _especificas in _citasMatricula.Tables[0].Rows)
            {
                Console.WriteLine(_especificas["FEC_MATRICULA"]);
            }
            Console.ReadLine();
        }
    }
}
